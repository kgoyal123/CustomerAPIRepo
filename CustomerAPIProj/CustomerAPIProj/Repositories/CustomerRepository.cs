using CustomerAPIProj.Data;
using CustomerAPIProj.Models.Domain;

namespace CustomerAPIProj.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext ncustomerDBContext;
        public CustomerRepository(CustomerDBContext ncustomerDBContext)
        {
            this.ncustomerDBContext = ncustomerDBContext;
        } 

        public IEnumerable<Customer> GetAll()
        {
            return ncustomerDBContext.Customers.ToList();

        }
    }
}
