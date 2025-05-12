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
      var cacheDirectory = options.Value.GetCacheDirectory();
      var fileName = $"{options.Value.Hostname}.xml";
      var filePath = Path.Combine(cacheDirectory, fileName);
      try
      {
        using var client = new HttpClient();
        client.Timeout = TimeSpan.FromMinutes(3);
        var url = new UriBuilder()
        {
          Scheme = "http",
          Path = "xmltv.php",
          Query = $"username={options.Value.Username}&password={options.Value.Password}",
          Host = options.Value.Hostname,
        };


        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url.Uri), cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
          logger.LogCritical("Unable to download m3u file {FilePath} ({StatusCode} {Reason})", filePath,
            response.StatusCode, response.ReasonPhrase);
          throw new RequestFailedException($"Unable to download m3u file {filePath}");
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
      }
      catch when (!File.Exists(filePath))
      {
        throw new RequestFailedException($"Unable to download m3u file {filePath}");
      }

      return Tv.Load(filePath);
    }
  }
}
