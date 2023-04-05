using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IConfiguration _config)
        {
            var client = new MongoClient(_config.GetValue<string>("DatabaseSetting:ConnectionString"));
            var database = client.GetDatabase(_config.GetValue<string>("DatabaseSetting:DatabaseName"));
            Products = database.GetCollection<Product>(_config.GetValue<string>("DatabaseSetting:CollectionName"));
        }

    }
}
