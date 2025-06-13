using System.Net.Http.Headers;
using MediatR;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Tivi.Models;

namespace Tivi;

public static partial class GetXmlTvPlaylist
{
    public record Request() : IRequest<Tv>;

    class Handler(
        IMinioClient minioClient,
        IOptions<TiviOptions> options,
        ILogger<Handler> logger) : IRequestHandler<Request, Tv>
    {
        public async Task<Tv> Handle(Request request, CancellationToken cancellationToken)
        {
            if (!await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(Constants.CacheBucketName),
                    cancellationToken))
            {
                await minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(Constants.CacheBucketName),
                    cancellationToken);
            }

            var fileName = $"{options.Value.Hostname}.xml";

            try
            {
                if (await minioClient.ExistsAsync(Constants.CacheBucketName, fileName, cancellationToken) is
                        { } stat &&
                    DateTime.Now.Subtract(TimeSpan.FromHours(1)) < stat.LastModified)
                {
                    return await minioClient.GetObject(Constants.CacheBucketName, fileName, Tv.Load, cancellationToken);
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

                logger.LogInformation("Downloading xmltv file {FilePath} from {Url}", fileName, url.Uri);

                var stream = await client.GetStreamAsync(url.Uri, cancellationToken);
                await minioClient.PutObjectAsync(new PutObjectArgs()
                    .WithBucket(Constants.CacheBucketName)
                    .WithObject(fileName)
                    .WithObjectStream(stream), cancellationToken);
                logger.LogInformation("Downloaded xmltv file {FilePath} from {Url}", fileName, url.Uri);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unable to download xmltv file {Url}", fileName);
                if (await minioClient.ExistsAsync(Constants.CacheBucketName, fileName, cancellationToken) is null)
                {
                    throw new RequestFailedException($"Unable to download xmltv file {fileName}", ex);
                }
            }

            try
            {
                return await minioClient.GetObject(Constants.CacheBucketName, fileName, Tv.Load, cancellationToken);
            }
            catch
            {
                if (await minioClient.ExistsAsync(Constants.CacheBucketName, fileName, cancellationToken) is { })
                {
                    await minioClient.RemoveObjectAsync(new RemoveObjectArgs()
                        .WithBucket(Constants.CacheBucketName)
                        .WithObject(fileName), cancellationToken);
                }

                throw;
            }
        }
    }
}
