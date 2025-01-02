using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services.Interfaces;

namespace DbTuning.Api.Services
{
    public class OrderDetailService(IOrderDetailRepository orderDetailRepository) : IOrderDetailService
    {
        public async Task<OrderDetail> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            return await orderDetailRepository.GetOrderDetailByIdAsync(orderId, productId);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await orderDetailRepository.GetOrderDetailsByOrderIdAsync(orderId);
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            await orderDetailRepository.AddOrderDetailAsync(orderDetail);
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            await orderDetailRepository.UpdateOrderDetailAsync(orderDetail);
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            await orderDetailRepository.DeleteOrderDetailAsync(orderId, productId);
        }
    }
}