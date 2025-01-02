using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services;
using Moq;
using Xunit;

namespace DbTuning.Tests.Services
{
    public class OrderDetailServiceTests
    {
        private readonly Mock<IOrderDetailRepository> _orderDetailRepositoryMock;
        private readonly OrderDetailService _orderDetailService;

        public OrderDetailServiceTests()
        {
            _orderDetailRepositoryMock = new Mock<IOrderDetailRepository>();
            _orderDetailService = new OrderDetailService(_orderDetailRepositoryMock.Object);
        }

        [Fact]
        public async Task GetOrderDetailsByOrderIdAsync_ReturnsOrderDetails()
        {
            // Arrange
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { OrderID = 1, ProductID = 1, Quantity = 2, Price = 1200.00M },
                new OrderDetail { OrderID = 1, ProductID = 2, Quantity = 1, Price = 800.00M }
            };
            _orderDetailRepositoryMock.Setup(repo => repo.GetOrderDetailsByOrderIdAsync(1))
                .ReturnsAsync(orderDetails);

            // Act
            var result = await _orderDetailService.GetOrderDetailsByOrderIdAsync(1);

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddOrderDetailAsync_CallsRepositoryOnce()
        {
            // Arrange
            var orderDetail = new OrderDetail { OrderID = 2, ProductID = 3, Quantity = 1, Price = 150.00M };

            // Act
            await _orderDetailService.AddOrderDetailAsync(orderDetail);

            // Assert
            _orderDetailRepositoryMock.Verify(repo => repo.AddOrderDetailAsync(orderDetail), Times.Once);
        }
    }
}