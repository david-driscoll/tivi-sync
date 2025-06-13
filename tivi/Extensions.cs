using BlobHelper;

namespace Tivi;

public static class Extensions
{
    public static async Task<BlobMetadata?> ExistsAsync(
        this BlobClient minioClient,
        string objectName,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await minioClient
                .GetMetadata(objectName, cancellationToken);

            return response;
        }
        catch
        {
            return null;
        }
    }
}
