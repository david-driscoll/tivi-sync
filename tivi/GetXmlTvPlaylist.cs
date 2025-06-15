using System.Net.Http.Headers;
using BlobHelper;
using MediatR;
using Microsoft.Extensions.Options;
using Rocket.Surgery.Extensions.Logging;
using Tivi.Models;

namespace Tivi;

public static partial class GetXmlTvPlaylist
{
    public record Request() : IRequest<Tv>;

    class Handler(
        [FromKeyedServices(Constants.CacheBucketName)]
        BlobClient minioClient,
        IOptions<TiviOptions> options,
        ILogger<Handler> logger) : IRequestHandler<Request, Tv>
    {
        public async Task<Tv> Handle(Request request, CancellationToken cancellationToken)
        {
            var fileName = $"{options.Value.Hostname}.xml";
            
            try
            {
                if (await minioClient.ExistsAsync(fileName, cancellationToken) is {} stat &&
                    DateTime.Now.Subtract(TimeSpan.FromHours(1)) < stat.LastUpdateUtc)
                {
                    var s = await minioClient.GetStream(fileName, cancellationToken);
                    using var reader = new StreamReader(s.Data);
                    return Tv.Load(await reader.ReadToEndAsync(cancellationToken));
                }

                using var client = new HttpClient()
                {
                    DefaultRequestHeaders =
                    {
                        UserAgent =
                        {
                            ProductInfoHeaderValue.Parse("VLC")
                        }
                    }
                };

                client.Timeout = TimeSpan.FromMinutes(10);
                var url = new UriBuilder()
                {
                    Scheme = "http",
                    Path = "xmltv.php",
                    Query = $"username={options.Value.Username}&password={options.Value.Password}",
                    Host = options.Value.Hostname,
                };
                
                using var _ = logger.TimeInformation("Downloading xmltv file {FilePath} from {Url}", fileName, url.Uri);

                var stream = await client.GetByteArrayAsync(url.Uri, cancellationToken);
                using var memoryStream = new MemoryStream(stream);
                using var streamReader = new StreamReader(memoryStream);
                var tv = Tv.Load(streamReader);
                await minioClient.Write(fileName, "text/plain", stream, cancellationToken);
                return tv;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unable to download xmltv file {Url}", fileName);
                if (!await minioClient.Exists(fileName, cancellationToken))
                {
                    throw new RequestFailedException($"Unable to download xmltv file {fileName}", ex);
                }
                var stream = await minioClient.GetStream(fileName, cancellationToken);
                using var reader = new StreamReader(stream.Data);
                return Tv.Load(await reader.ReadToEndAsync(cancellationToken));
            }
        }
    }
}
