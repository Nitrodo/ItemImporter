using System;
using System.Threading.Tasks;
using ItemImporter.Common.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ItemImporter.Functions
{
    public class GetItemsFromFTPFunction
    {
        private readonly IFtpService _ftpService;
        private readonly IBlobStorageService _blobStorageService;
        public GetItemsFromFTPFunction(IFtpService ftpService,
                                       IBlobStorageService blobStorageService)
        {
            _ftpService= ftpService ?? throw new ArgumentNullException(nameof(ftpService));
            _blobStorageService = blobStorageService ?? throw new ArgumentNullException(nameof(blobStorageService));
        }

        [FunctionName("GetItemsFromFTP")]
        public async Task RunAsync([TimerTrigger("0 */1 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Start function GetItemsFromFTP at: {DateTime.Now}");

            // 1. Read all files from FTP
            var files = _ftpService.DownloadAllFilesAsync("input");

            // 2. Save data in Blobstorage (via service)
            await foreach (var file in files)
            {
                var isSuccess = _blobStorageService.Write(file, "items");
                if (isSuccess)
                {
                    await _ftpService.DeleteFileAsync(file.FullName);
                }
            }

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
