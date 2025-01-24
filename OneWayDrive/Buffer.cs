using System.Collections.Concurrent;

namespace OneWayDrive;

public class Buffer(ILogger<Buffer> logger)
{
    private readonly BlockingCollection<string> buffer = new();

    public BlockingCollection<string> Files => buffer;

    public void Add(string file)
    {
        buffer.Add(file);
        logger.LogInformation("Buffer added file {file}", file);
    }
}