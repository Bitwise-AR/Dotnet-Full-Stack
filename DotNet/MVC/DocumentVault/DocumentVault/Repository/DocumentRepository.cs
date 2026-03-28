using Microsoft.EntityFrameworkCore;
using DocumentVault.Data;
using DocumentVault.Models;

namespace DocumentVault.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task<Document> GetByIdAsync(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _context.Documents
                .OrderByDescending(x => x.UploadedAt)
                .ToListAsync();
        }
    }
}
