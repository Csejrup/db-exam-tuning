using DbTuning.Api.Data;
using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbTuning.Api.Repositories
{
    public class OrderDetailRepository(AppDbContext context) : IOrderDetailRepository
    {
        public async Task<OrderDetail> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            return await context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .FirstOrDefaultAsync(od => od.OrderID == orderId && od.ProductID == productId) ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await context.OrderDetails
                .Where(od => od.OrderID == orderId)
                .Include(od => od.Product)
                .ToListAsync();
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            await context.OrderDetails.AddAsync(orderDetail);
            await context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            context.OrderDetails.Update(orderDetail);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            var orderDetail = await GetOrderDetailByIdAsync(orderId, productId);
            if (orderDetail != null)
            {
                context.OrderDetails.Remove(orderDetail);
                await context.SaveChangesAsync();
            }
        }
    }
}