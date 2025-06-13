using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using BlobHelper;
using M3UManager.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace Tivi;

public static partial class GetM3UPlaylist
{
    public record Request() : IRequest<M3U>;

    class Handler(
        [FromKeyedServices(Constants.CacheBucketName)]
        BlobClient minioClient,
        IOptions<TiviOptions> options,
        ILogger<Handler> logger) : IRequestHandler<Request, M3U>
    {
        public async Task<M3U> Handle(Request request, CancellationToken cancellationToken)
        {
            var fileName = $"{options.Value.Hostname}.m3u";

            try
            {

                if (await minioClient.ExistsAsync(fileName, cancellationToken) is {} stat &&
                    DateTime.Now.Subtract(TimeSpan.FromHours(1)) < stat.LastUpdateUtc)
                {
                    var s = await minioClient.GetStream(fileName, cancellationToken);
                    using var reader = new StreamReader(s.Data);
                    return M3UManager.M3UManager.ParseFromString(await reader.ReadToEndAsync(cancellationToken));
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
                    Path = "get.php",
                    Query =
                        $"username={options.Value.Username}&password={options.Value.Password}&type=m3u_plus&output=ts",
                    Host = options.Value.Hostname,
                };

                logger.LogInformation("Downloading m3u file {FilePath} from {Url}", fileName, url.Uri);

                var stream = await client.GetByteArrayAsync(url.Uri, cancellationToken);
                await minioClient.Write(fileName, "application/x-mpegURL", stream, cancellationToken);

                logger.LogInformation("Downloaded m3u file {FilePath} from {Url}", fileName, url.Uri);
                return M3UManager.M3UManager.ParseFromString(Encoding.UTF8.GetString(stream));
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unable to download xmltv file {Url}", fileName);
                if (await minioClient.Exists(fileName, cancellationToken) is false)
                {
                    throw new RequestFailedException($"Unable to download xmltv file {fileName}", ex);
                }
                var stream = await minioClient.GetStream(fileName, cancellationToken);
                using var reader = new StreamReader(stream.Data);
                return M3UManager.M3UManager.ParseFromString(await reader.ReadToEndAsync(cancellationToken));
            }
        }

    }
}
