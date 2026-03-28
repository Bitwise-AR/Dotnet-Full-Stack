using DocumentVault.Models;

namespace DocumentVault.Repository
{
    public interface IDocumentRepository
    {
        Task AddAsync(Document document);
        Task<Document> GetByIdAsync(int id);
        Task<List<Document>> GetAllAsync();
    }
}
