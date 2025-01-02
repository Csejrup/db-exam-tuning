using DbTuning.Api.Data;
using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbTuning.Api.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderDetails)
                .FirstOrDefaultAsync(c => c.CustomerID == id) ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await context.Customers
                .Include(c => c.Orders)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> SearchCustomersByNameAsync(string name)
        {
            return await context.Customers
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            context.Customers.Update(customer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await GetCustomerByIdAsync(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
        }
    }
}