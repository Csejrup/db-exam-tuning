using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services.Interfaces;

namespace DbTuning.Api.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await productRepository.GetProductByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await productRepository.GetAllProductsAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            return await productRepository.GetProductsByCategoryAsync(category);
        }

        public async Task AddProductAsync(Product product)
        {
            await productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await productRepository.DeleteProductAsync(id);
        }
    }
}