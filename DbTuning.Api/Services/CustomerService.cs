using DbTuning.Api.Models;
using DbTuning.Api.Repositories.Interfaces;
using DbTuning.Api.Services.Interfaces;

namespace DbTuning.Api.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await customerRepository.GetAllCustomersAsync();
        }

        public async Task<IEnumerable<Customer>> SearchCustomersByNameAsync(string name)
        {
            return await customerRepository.SearchCustomersByNameAsync(name);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await customerRepository.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await customerRepository.DeleteCustomerAsync(id);
        }
    }
}