using DocumentVault.Models;

namespace DocumentVault.Services
{
    public interface IDocumentService
    {
        Task<int> UploadAsync(IFormFile file, string uploadedBy);
        Task<(byte[], string, string)> DownloadAsync(int id);
        Task<List<Document>> GetAllAsync();
    }
}
