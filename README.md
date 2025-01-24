# OneWayDrive

## Motivation

Learning project

## Requirements

Using a .NET background worker project

Create a file system watcher to watch for files being added to a directory

Then upload that file to an Azure Storage Account

# Learning Goals

## Creating a Service Worker

Worker Service Project Template -> https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service

## Managing secrets

.NET User Secrets -> https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=linux

## Application Configuration

Configuration in .NET -> https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-9.0

## Event Handlers

Subscribing to events -> https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events

## .NET Dependency Injection

Dependency Injection -> https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection

## .NET Logging

Logging in C# and .NET -> https://learn.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line

## Azure

Feel free to use Azurite Storage Emulator -> https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio%2Cblob-storage

Or you can use a real Azure Storage Account

# To start or debug this application you will need:

1. One of the following options for uploading files  
	1. Actual Storage Account provisioned on Azure  
	2. Azurite Storage Emulator  
	3. Rancher Desktop installed on your machine to run the Azureite Storage Emulator container  
2. The user secret named "StorageConnection" for the Storage Account connneciton string  
	1. For emulators: use the value "UseDevelopmentStorage=true"  
	2. For actual Storage Account, use the connection string value copied from the Azure Portal  

```cs
# Use the following command in your terminal to set the user secret
# this command needs to be run in the same directory as the OneWayDrive.csproj file.
dotnet user-secrets set StorageConnection "UseDevelopmentStorage=true"
```



