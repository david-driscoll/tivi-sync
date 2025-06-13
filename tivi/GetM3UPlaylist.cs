using System.Net.Http.Headers;
using M3UManager.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.ILM;

namespace Tivi;

public static partial class GetM3UPlaylist
{
    public record Request() : IRequest<M3U>;

    class Handler(
        IMinioClient minioClient,
        IOptions<TiviOptions> options,
        ILogger<Handler> logger) : IRequestHandler<Request, M3U>
    {
        public async Task<M3U> Handle(Request request, CancellationToken cancellationToken)
        {
            if (!await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(Constants.CacheBucketName),
                    cancellationToken))
            {
                await minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(Constants.CacheBucketName),
                    cancellationToken);
            }

            var fileName = $"{options.Value.Hostname}.m3u";

            if (await minioClient.ExistsAsync(Constants.CacheBucketName, fileName, cancellationToken) is {} stat &&
                DateTime.Now.Subtract(TimeSpan.FromHours(1)) < stat.LastModified)
            {
                return await minioClient.GetObject(Constants.CacheBucketName, fileName, async reader => M3UManager.M3UManager.ParseFromString(await reader.ReadToEndAsync(cancellationToken)), cancellationToken);
            }

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
                    Path = "get.php",
                    Query =
                        $"username={options.Value.Username}&password={options.Value.Password}&type=m3u_plus&output=ts",
                    Host = options.Value.Hostname,
                };

                logger.LogInformation("Downloading m3u file {FilePath} from {Url}", fileName, url.Uri);

                var stream = await client.GetStreamAsync(url.Uri, cancellationToken);
                await minioClient.PutObjectAsync(new PutObjectArgs()
                    .WithBucket(Constants.CacheBucketName)
                    .WithObject(fileName)
                    .WithObjectStream(stream), cancellationToken);

                logger.LogInformation("Downloaded m3u file {FilePath} from {Url}", fileName, url.Uri);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unable to download m3u file {Url}", fileName);
                if (await minioClient.ExistsAsync(Constants.CacheBucketName, fileName, cancellationToken) is null)
                {
                    throw new RequestFailedException($"Unable to download m3u file {fileName}", ex);
                }
            }

            try
            {
                return await minioClient.GetObject(Constants.CacheBucketName, fileName, async reader => M3UManager.M3UManager.ParseFromString(await reader.ReadToEndAsync(cancellationToken)), cancellationToken);
            }
            catch
            {
                if (await minioClient.ExistsAsync(Constants.CacheBucketName, fileName, cancellationToken) is {})
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
