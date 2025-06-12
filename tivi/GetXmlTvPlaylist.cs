using System.Net.Http.Headers;
using System.Xml;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using tivi.Models;

public static partial class GetXmlTvPlaylist
{
    public record Request() : IRequest<Tv>;

    class Handler(
        IOptions<TiviOptions> options,
        ILogger<Handler> logger) : IRequestHandler<Request, Tv>
    {
        public async Task<Tv> Handle(Request request, CancellationToken cancellationToken)
        {
            var cacheDirectory = options.Value.CacheDirectory;
            var fileName = $"{options.Value.Hostname}.xml";
            var filePath = Path.Combine(cacheDirectory, fileName);
            
            try
            {
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

                logger.LogInformation("Downloading xmltv file {FilePath} from {Url}", filePath, url.Uri);

                if (!Directory.Exists(cacheDirectory))
                {
                    Directory.CreateDirectory(cacheDirectory);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                var stream = await client.GetStreamAsync(url.Uri, cancellationToken);
                await using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(fileStream, cancellationToken);
                logger.LogInformation("Downloaded xmltv file {FilePath} from {Url}", filePath, url.Uri);
            }
            catch (Exception ex) when (!File.Exists(filePath))
            {
                logger.LogCritical(ex, "Unable to download xmltv file {Url}", filePath);
                throw new RequestFailedException($"Unable to download xmltv file {filePath}", ex);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unable to download xmltv file {Url}", filePath);
            }

            try
            {
                return Tv.Load(filePath);
            }
            catch when (File.Exists(filePath))
            {
                File.Delete(filePath);
                throw;
            }
        }
    }
}
