namespace OneWayDrive;

public class Watcher
{
    private readonly Buffer buffer;
    private readonly string filter;
    private readonly ILogger<Watcher> logger;
    private readonly string path;
    private readonly FileSystemWatcher watcher;

    public Watcher(ILogger<Watcher> logger, Buffer buffer, IConfiguration configuration)
    {
        this.path = configuration["FileWatcherPath"] ?? throw new ArgumentNullException(nameof(configuration));
        this.filter = configuration["FileWatcherFilter"] ?? throw new ArgumentNullException(nameof(configuration));
        this.watcher = new(path, filter);
        this.watcher.Disposed += HandleDisposed;
        this.logger = logger;
        this.buffer = buffer;
    }

    public void Start()
    {
        if (!Directory.Exists(path))
        {
            throw new Exception("Directory does not exist");
        }
        watcher.EnableRaisingEvents = true;
        watcher.Created += HandleCreated;

        logger.LogInformation("Watcher has started for directory {path}", path);
    }

    public void Stop()
    {
        watcher.EnableRaisingEvents = false;
        watcher.Created -= HandleCreated;
        logger.LogInformation("Watcher has stopped for directory {path}", path);
    }

    private void HandleCreated(object sender, FileSystemEventArgs e)
    {
        logger.LogInformation("Watcher file created at: {time}", DateTimeOffset.Now);
        buffer.Add(e.FullPath);
    }

    private void HandleDisposed(object? sender, EventArgs e)
    {
        logger.LogInformation("Watcher has stopped unexpectedly");
    }
}