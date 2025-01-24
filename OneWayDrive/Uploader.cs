using Azure.Storage.Blobs;

namespace OneWayDrive;

public class Uploader(ILogger<Uploader> logger, Buffer buffer, IConfiguration configuration)
{
    public async Task Start()
    {
        logger.LogInformation("Uploader waiting for files");
        foreach (var item in buffer.Files.GetConsumingEnumerable())
        {
            await Upload(item);
        }
    }

    public void Stop()
    {
        logger.LogInformation("Uploader stopping");
        buffer.Files.CompleteAdding();
    }

    private async Task Upload(string item)
    {
        string? connectionString = configuration["StorageConnection"] ?? throw new ArgumentNullException(nameof(configuration));
        string? containerName = configuration["BlobContainerName"] ?? throw new ArgumentNullException(nameof(configuration));
        logger.LogInformation("Uploader uploading file {file}", item);
        BlobContainerClient containerClient = new(connectionString, containerName);
        await containerClient.CreateIfNotExistsAsync();
        var blob = containerClient.GetBlobClient(Path.GetFileName(item));
        await blob.UploadAsync(item, true);
    }
}