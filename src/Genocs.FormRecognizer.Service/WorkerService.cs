﻿using Azure;
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Training;
using Genocs.Integration.CognitiveServices.Options;
using Microsoft.Extensions.Options;

namespace Genocs.FormRecognizer.Service;

class WorkerService : IHostedService, IDisposable
{
    private bool _disposed;

    private readonly ILogger<WorkerService> _logger;
    private readonly AzureCognitiveServicesConfig _configCognitiveServices;
    private readonly AzureStorageConfig _configAzureStorage;

    public WorkerService(ILogger<WorkerService> logger,
        IOptions<AzureCognitiveServicesConfig> configCognitiveServices,
        IOptions<AzureStorageConfig> configAzureStorage)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configCognitiveServices = configCognitiveServices.Value;
        _configAzureStorage = configAzureStorage.Value;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start worker service");

        await RunAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping Worker Service gracefully");
        return Task.CompletedTask;
    }


    /// <summary>
    /// Dispose() calls Dispose(true)
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    /// <summary>
    /// The bulk of the clean-up code is implemented in Dispose(bool)
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            // free managed resources
        }

        // free native resources if there are any.

        _disposed = true;
    }



    private async Task RunAsync()
    {


        string modelId = "40763499-a146-4202-be20-0418510ae1e4";
        //string modelName = "2021_04_08_01";
        string filePath = @"C:\tmp\uno.jpg";

        //EvaluateExisting(endpoint, apiKey, _logger);

        // Remove the comment on the line below to create a new model
        //await CreateModel(endpoint, apiKey, trainingSetUrl, modelName);
        //await TestLocal(endpoint, apiKey, modelId, filePath, _logger);
        //await TestUrl(endpoint, apiKey, modelId, fileUrl, _logger);

        await Task.CompletedTask;
        _logger.LogInformation("Done Successfully!");
    }
}
