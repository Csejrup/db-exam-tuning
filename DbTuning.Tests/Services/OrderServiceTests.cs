using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services;
using Moq;
using Xunit;

namespace DbTuning.Tests.Services
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderService = new OrderService(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllOrdersAsync_ReturnsAllOrders()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerID = 1, OrderDate = DateTime.Now, Total = 1350.00M },
                new Order { OrderID = 2, CustomerID = 2, OrderDate = DateTime.Now, Total = 950.00M }
            };
            _orderRepositoryMock.Setup(repo => repo.GetAllOrdersAsync())
                                .ReturnsAsync(orders);

            // Act
            var result = await _orderService.GetAllOrdersAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetOrderByIdAsync_ReturnsOrder_WhenOrderExists()
        {
            // Arrange
            var order = new Order { OrderID = 1, CustomerID = 1, OrderDate = DateTime.Now, Total = 1350.00M };
            _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(1))
                                .ReturnsAsync(order);

            // Act
            var result = await _orderService.GetOrderByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1350.00M, result.Total);
        }

        [Fact]
        public async Task AddOrderAsync_CallsRepositoryOnce()
        {
            // Arrange
            var order = new Order { OrderID = 3, CustomerID = 1, OrderDate = DateTime.Now, Total = 500.00M };

            // Act
            await _orderService.AddOrderAsync(order);

            // Assert
            _orderRepositoryMock.Verify(repo => repo.AddOrderAsync(order), Times.Once);
        }
    }
}
