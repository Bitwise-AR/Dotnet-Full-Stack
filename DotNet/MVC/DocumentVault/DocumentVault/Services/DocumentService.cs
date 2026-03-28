using DocumentVault.Repository;
using DocumentVault.Models;

namespace DocumentVault.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repo;
        private readonly GridFsService _gridFs;

        public DocumentService(IDocumentRepository repo, GridFsService gridFs)
        {
            _repo = repo;
            _gridFs = gridFs;
        }

        public async Task<int> UploadAsync(IFormFile file, string uploadedBy)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Invalid file");

            using var stream = file.OpenReadStream();

            // Upload to Mongo
            var gridId = await _gridFs.UploadAsync(stream, file.FileName);

            var doc = new Document
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Size = file.Length,
                GridFsId = gridId,
                UploadedBy = uploadedBy
            };

            await _repo.AddAsync(doc);

            return doc.Id;
        }

        public async Task<(byte[], string, string)> DownloadAsync(int id)
        {
            var doc = await _repo.GetByIdAsync(id);
            if (doc == null) throw new Exception("Not found");

            var fileBytes = await _gridFs.DownloadAsync(doc.GridFsId);

            return (fileBytes, doc.ContentType, doc.FileName);
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
