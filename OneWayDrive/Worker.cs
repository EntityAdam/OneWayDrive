namespace OneWayDrive;

public class Worker(Watcher watcher, Uploader uploader, ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("OneWayDrive worker started at: {time}", DateTimeOffset.Now);
        watcher.Start();
        await uploader.Start();
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("OneWayDrive worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000 * 60, stoppingToken);
        }
        logger.LogInformation("OneWayDrive worker stopping at: {time}", DateTimeOffset.Now);
    }
}