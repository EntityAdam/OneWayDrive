using OneWayDrive;
using Buffer = OneWayDrive.Buffer;

// https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<Watcher>();
builder.Services.AddSingleton<Buffer>();
builder.Services.AddSingleton<Uploader>();

var host = builder.Build();
await host.RunAsync();