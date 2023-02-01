using FluentFTP;
using ItemImporter.Common.Models;
using ItemImporter.Common.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ItemImporter.Common.Services
{
    public class FtpService : IFtpService
    {
        private readonly ILogger<FtpService> _logger;
        private readonly IAsyncFtpClient _client;

        public FtpService(ILogger<FtpService> logger, IAsyncFtpClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));

            // Skip certification for development purpose.
            _client.ValidateCertificate += (control, e) =>
            {
                e.Accept = true;
            };

            _client.AutoConnect();
        }

        public async IAsyncEnumerable<FileWrapper> DownloadAllFilesAsync(string location)
        {
            _logger.LogInformation($"Download all files from FTP");

            if (string.IsNullOrEmpty(location))
            {
                _logger.LogError($"Not able to download files. 'location' parameter is empty");
            }

            await foreach (var file in GetListingAsync(location))
            {
                _logger.LogInformation($"Downloading file {file.Name}");

                MemoryStream stream = new();

                try
                {
                    var isSuccess = await _client.DownloadStream(stream, file.FullName);
                    if (!isSuccess)
                    {
                        _logger.LogWarning($"Not able to download file {file.Name} from FTP");
                    }
                }
                catch
                {
                    _logger.LogWarning($"Something went wrong downloading file {file.Name} from FTP");
                }

                yield return new FileWrapper { Name = file.Name, FullName = file.FullName, Stream = stream };          
            }
        }

        public async IAsyncEnumerable<FtpListItem> GetListingAsync(string location)
        {
            var items = Array.Empty<FtpListItem>();

            if (string.IsNullOrEmpty(location))
            {
                _logger.LogError($"Not able to list files. 'location' parameter is empty");
            }

            try
            {
                items = await _client.GetListing(location);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Not able to list files from FTP: {ex}");
            }

            foreach (FtpListItem item in items)
            {
                if (item.Type == FtpObjectType.File)
                {
                    yield return item;
                }
            }
        }

        public async Task DeleteFileAsync(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                _logger.LogError($"Not able to delete file. 'fullName' parameter is empty");
                return;
            }

            try
            {
                await _client.DeleteFile(fullName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Not able to delete file {fullName} from FTP: {ex}");
            }
        }
    }
}
