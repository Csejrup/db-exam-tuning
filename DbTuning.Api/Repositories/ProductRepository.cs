using DbTuning.Api.Data;
using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbTuning.Api.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            return await context.Products
                .Where(p => p.Category == category)
                .ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }
    }
}