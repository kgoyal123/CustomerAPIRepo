using CustomerAPIProj.Models.Domain;

namespace CustomerAPIProj.Repositories
{
    public interface ICustomerRepository
    {
        Task <IEnumerable<Customer>>GetAllAsync();

        Task<Customer> GetAsync(Guid Id);

        Task<Customer> AddAsynch(Customer customer);

        Task<Customer> DeleteAsync(Guid Id);

        Task<Customer> UpdateAsynch(Guid Id,Customer customer);


    }
}
