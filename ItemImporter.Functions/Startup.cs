using Azure.Storage.Blobs;
using FluentFTP;
using ItemImporter.Common.Services;
using ItemImporter.Common.Services.Interfaces;
using ItemImporter.Functions.Mappers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(ItemImporter.Functions.Startup))]

namespace ItemImporter.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddAzureClients(clientBuilder => clientBuilder.AddBlobServiceClient("DefaultEndpointsProtocol=https;AccountName=nicotest2023;AccountKey=nbrx1y2rY7TgYzufiC/QQDAv7dXy4ZLhYrc8LQBIoCMyBIMDa8Vnb6+ffcS/IyUlKrlx19nJvFs8+AStW7HFwQ==;BlobEndpoint=https://nicotest2023.blob.core.windows.net/;TableEndpoint=https://nicotest2023.table.core.windows.net/;QueueEndpoint=https://nicotest2023.queue.core.windows.net/;FileEndpoint=https://nicotest2023.file.core.windows.net/"));
            builder.Services.AddAutoMapper(typeof(MappingConfiguration));
            builder.Services.AddScoped<IFtpService, FtpService>((s) =>
            {
                return new FtpService(s.GetRequiredService<ILogger<FtpService>>(), new AsyncFtpClient("ftp://127.0.0.1", "devUser", "Password123!"));
            });
            builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();
        }
    }
}
