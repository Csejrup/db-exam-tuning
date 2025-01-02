using DbTuning.Api.Data;
using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbTuning.Api.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderID == id) ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await context.Orders
                                 .Include(o => o.Customer)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await context.Orders
                                 .Where(o => o.CustomerID == customerId)
                                 .Include(o => o.Customer)
                                 .Include(o => o.OrderDetails)
                                 .ThenInclude(od => od.Product)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersWithinDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await context.Orders
                                 .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                                 .Include(o => o.Customer)
                                 .Include(o => o.OrderDetails)
                                 .ThenInclude(od => od.Product)
                                 .ToListAsync();
        }

        public async Task AddOrderAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await GetOrderByIdAsync(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
        }
    }
}
