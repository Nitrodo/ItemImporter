using Azure.Storage.Blobs;
using ItemImporter.Common.Models;
using ItemImporter.Common.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ItemImporter.Common.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly ILogger<BlobStorageService> _logger;
        private readonly BlobServiceClient _serviceClient;

        public BlobStorageService(ILogger<BlobStorageService> logger,
                                  BlobServiceClient serviceClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _serviceClient = serviceClient ?? throw new ArgumentNullException(nameof(serviceClient));
            ;
        }

        public bool Write(FileWrapper file, string containerName)
        {
            if (file.Stream == null)
            {
                _logger.LogInformation("No file found to save in the Blob Storage");
                return false;
            }

            try
            {
                var containerClient = _serviceClient.GetBlobContainerClient(containerName);
                file.Stream.Position = 0;
                var blobClient = containerClient.GetBlobClient(file.Name);
                var result = blobClient.Upload(file.Stream);

                _logger.LogInformation($"Successfully uploaded file {file.Name}");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong with uploading file {file.Name} to the Blob Storeage: {ex}");
                return false;
            }
        }
    }
}
