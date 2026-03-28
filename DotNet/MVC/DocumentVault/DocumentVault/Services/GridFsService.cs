namespace DocumentVault.Services
{
    using MongoDB.Driver;
    using MongoDB.Driver.GridFS;

    public class GridFsService
    {
        private readonly GridFSBucket _bucket;

        public GridFsService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDbSettings:DatabaseName"]);

            _bucket = new GridFSBucket(database);
        }

        public async Task<string> UploadAsync(Stream stream, string fileName)
        {
            var id = await _bucket.UploadFromStreamAsync(fileName, stream);
            return id.ToString();
        }

        public async Task<byte[]> DownloadAsync(string id)
        {
            return await _bucket.DownloadAsBytesAsync(new MongoDB.Bson.ObjectId(id));
        }
    }
}
