using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services;
using Moq;
using Xunit;

namespace DbTuning.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 1200.00M, Stock = 50 },
                new Product { ProductID = 2, Name = "Table", Category = "Furniture", Price = 150.00M, Stock = 20 }
            };
            _productRepositoryMock.Setup(repo => repo.GetAllProductsAsync())
                                  .ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllProductsAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Name == "Laptop");
            Assert.Contains(result, p => p.Name == "Table");
        }

        [Fact]
        public async Task GetProductByIdAsync_ReturnsProduct_WhenProductExists()
        {
            // Arrange
            var product = new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 1200.00M, Stock = 50 };
            _productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(1))
                                  .ReturnsAsync(product);

            // Act
            var result = await _productService.GetProductByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Laptop", result.Name);
        }

        [Fact]
        public async Task GetProductByIdAsync_ReturnsNull_WhenProductDoesNotExist()
        {
            // Arrange
            _productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(999))
                                  .ReturnsAsync((Product)null);

            // Act
            var result = await _productService.GetProductByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddProductAsync_CallsRepositoryOnce()
        {
            // Arrange
            var product = new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 1200.00M, Stock = 50 };

            // Act
            await _productService.AddProductAsync(product);

            // Assert
            _productRepositoryMock.Verify(repo => repo.AddProductAsync(product), Times.Once);
        }
    }
}
