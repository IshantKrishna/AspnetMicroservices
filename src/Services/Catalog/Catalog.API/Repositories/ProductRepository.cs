using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _catalogContext.Products.Find(p => true).ToListAsync();
        }
                            
        public async Task<Product> GetProductAsync(string id)
        {
            return await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await _catalogContext.Products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, category);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task CreateProductAsync(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
           var ack = await _catalogContext.Products.ReplaceOneAsync(filter: r => r.Id == product.Id,
               replacement: product);
           return ack.IsAcknowledged && ack.MatchedCount > 0;
        }

        public async Task<bool> DeleteProductAsync(string id)
        { 
            var ack = await _catalogContext.Products.DeleteOneAsync(filter: p => p.Id == id);
            return ack.IsAcknowledged && ack.DeletedCount > 0;
        }
    }
}
