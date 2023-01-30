using CustomerAPIProj.Models.Domain;

namespace CustomerAPIProj.Repositories
{
    public interface ICustomerRepository
    {
        Task <IEnumerable<Customer>>GetAll();
    }
}
