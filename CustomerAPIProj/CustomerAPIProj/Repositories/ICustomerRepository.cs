using CustomerAPIProj.Models.Domain;

namespace CustomerAPIProj.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();

        Task<Customer?> GetCustomer(int Id);

        Task<Customer> AddCustomer(Customer customer);

        Task<bool> DeleteCustomer(int Id);

        Task<Customer?> UpdateCustomer(Customer customer);


    }
}
