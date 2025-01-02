using DbTuning.Api.Models;

namespace DbTuning.Api.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> GetOrderDetailByIdAsync(int orderId, int productId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task AddOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int orderId, int productId);
    }
}