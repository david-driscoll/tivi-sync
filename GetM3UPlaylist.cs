using M3UManager.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public static partial class GetM3UPlaylist
{
    public record Request() : IRequest<M3U>;

    class Handler(
        IOptions<TiviOptions> options,
        ILogger<Handler> logger) : IRequestHandler<Request, M3U>
    {
        public async Task<M3U> Handle(Request request, CancellationToken cancellationToken)
        {
            var cacheDirectory = options.Value.CacheDirectory;
            var fileName = $"{options.Value.Hostname}.m3u";
            var filePath = Path.Combine(cacheDirectory, fileName);
            // if (File.Exists(filePath) &&
            //     DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)) < File.GetLastWriteTimeUtc(filePath))
            // {
            //     return M3UManager.M3UManager.ParseFromFile(filePath);
            // }

            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(3);
                var url = new UriBuilder()
                {
                    Scheme = "http",
                    Path = "get.php",
                    Query =
                        $"username={options.Value.Username}&password={options.Value.Password}&type=m3u_plus&output=ts",
                    Host = options.Value.Hostname,
                };

                logger.LogInformation("Downloading m3u file {FilePath} from {Url}", filePath, url.Uri);

                var response =
                    await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url.Uri), cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    logger.LogCritical("Unable to download m3u file {Url} ({StatusCode} {Reason})", url.Uri,
                        response.StatusCode, response.ReasonPhrase);
                    logger.LogCritical("Response: {Response}",
                        await response.Content.ReadAsStringAsync(cancellationToken));
                    throw new RequestFailedException($"Unable to download m3u file {url.Uri}");
                }

                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

                if (!Directory.Exists(cacheDirectory))
                {
                    Directory.CreateDirectory(cacheDirectory);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                await using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(fileStream, cancellationToken);

                logger.LogInformation("Downloaded m3u file {FilePath} from {Url}", filePath, url.Uri);
            }
            catch (Exception ex) when (!File.Exists(filePath))
            {
                logger.LogCritical(ex, "Unable to download m3u file {Url}", filePath);
                throw new RequestFailedException($"Unable to download m3u file {filePath}", ex);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unable to download m3u file {Url}", filePath);
            }

            return M3UManager.M3UManager.ParseFromFile(filePath);
        }
    }
}