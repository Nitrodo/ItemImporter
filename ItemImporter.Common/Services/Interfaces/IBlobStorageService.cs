using ItemImporter.Common.Models;

namespace ItemImporter.Common.Services.Interfaces
{
    public interface IBlobStorageService
    {
        bool Write(FileWrapper files, string containerName);
    }
}
