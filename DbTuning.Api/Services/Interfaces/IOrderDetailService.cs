using DbTuning.Api.Models;

namespace DbTuning.Api.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> GetOrderDetailByIdAsync(int orderId, int productId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task AddOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int orderId, int productId);
    }
}