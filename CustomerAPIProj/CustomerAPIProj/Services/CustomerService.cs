using CustomerAPIProj.Models.Domain;
using CustomerAPIProj.Repositories;
using CustomerAPIProj.Services.IServices;

namespace CustomerAPIProj.Services
{
    public class CustomerService:ICustomer
    {
        public readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            return await _customerRepository.AddCustomer(customer);
        }

        public async Task<bool> DeleteCustomer(int Id)
        {
            
            return await _customerRepository.DeleteCustomer(Id);
        }

        
        List<Customer> ICustomer.GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        async Task<Customer?> ICustomer.GetCustomer(int Id)
        {
            return await _customerRepository.GetCustomer(Id);
        }

        Task<Customer?> ICustomer.UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        //async Task<Customer> ICustomer.UpdateCustomer(Customer customer)
        //{
        //    return await _customerRepository.UpdateCustomer(customer);

        //}
    }
}
