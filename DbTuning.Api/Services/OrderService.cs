using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services.Interfaces;

namespace DbTuning.Api.Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await orderRepository.GetOrderByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await orderRepository.GetAllOrdersAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await orderRepository.GetOrdersByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<Order>> GetOrdersWithinDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await orderRepository.GetOrdersWithinDateRangeAsync(startDate, endDate);
        }

        public async Task AddOrderAsync(Order order)
        {
            await orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await orderRepository.DeleteOrderAsync(id);
        }
    }
}