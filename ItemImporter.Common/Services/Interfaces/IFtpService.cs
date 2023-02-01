using FluentFTP;
using ItemImporter.Common.Models;

namespace ItemImporter.Common.Services.Interfaces
{
    public interface IFtpService
    {
        IAsyncEnumerable<FileWrapper> DownloadAllFilesAsync(string location);
        IAsyncEnumerable<FtpListItem> GetListingAsync(string location);
        Task DeleteFileAsync(string fullName);
    }
}
