using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services;
using Moq;
using Xunit;

namespace DbTuning.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_customerRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllCustomersAsync_ReturnsAllCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { CustomerID = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "123456" },
                new Customer { CustomerID = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "654321" }
            };
            _customerRepositoryMock.Setup(repo => repo.GetAllCustomersAsync())
                                   .ReturnsAsync(customers);

            // Act
            var result = await _customerService.GetAllCustomersAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SearchCustomersByNameAsync_ReturnsMatchingCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { CustomerID = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "123456" }
            };
            _customerRepositoryMock.Setup(repo => repo.SearchCustomersByNameAsync("John"))
                                   .ReturnsAsync(customers);

            // Act
            var result = await _customerService.SearchCustomersByNameAsync("John");

            // Assert
            Assert.Single(result);
            Assert.Equal("John Doe", result.First().Name);
        }
    }
}
