using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Tivi;

public static class Extensions
{
    public static PutObjectArgs WithObjectStream(this PutObjectArgs args, Stream stream)
    {
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();

        args.WithStreamData(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
            .WithObjectSize(content.Length)
            .WithModifiedSince(DateTime.Now);
        return args;
    }

    public static async Task<T> GetObject<T>(
        this IMinioClient minioClient,
        string bucketName,
        string fileName,
        Func<StreamReader, T> createItem,
        CancellationToken cancellationToken)
        where T : class
    {
        T result = null!;
        await minioClient.GetObjectAsync(new GetObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileName)
            .WithCallbackStream(stream =>
            {
                using var reader = new StreamReader(stream);
                result = createItem(reader);
            }), cancellationToken);
        return result;
    }

    public static async Task<T> GetObject<T>(
        this IMinioClient minioClient,
        string bucketName,
        string fileName,
        Func<StreamReader, Task<T>> createItem,
        CancellationToken cancellationToken)
        where T : class
    {
        T result = null!;
        await minioClient.GetObjectAsync(new GetObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileName)
            .WithCallbackStream(stream =>
            {
                using var reader = new StreamReader(stream);
                result = createItem(reader).GetAwaiter().GetResult();
            }), cancellationToken);
        return result;
    }

    public static async Task<ObjectStat?> ExistsAsync(
        this IMinioClient minioClient,
        string bucketName,
        string objectName,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await minioClient
                .StatObjectAsync(new StatObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName), cancellationToken);

            return response;
        }
        catch (ObjectNotFoundException)
        {
            return null;
        }
    }
}
