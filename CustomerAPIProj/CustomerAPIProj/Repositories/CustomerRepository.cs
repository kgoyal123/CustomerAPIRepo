using Customer = CustomerAPIProj.Models.Domain.Customer;
namespace CustomerAPIProj.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly static Dictionary<int, Customer> dictionary = new Dictionary<int, Customer>();
        
        public async Task<Customer> AddCustomer(Customer customer)
        {
            await Task.Run(() =>
            {
                dictionary.TryAdd(customer.Id, new Customer{ CustName = customer.CustName, CustAge = customer.CustAge, Email = customer.Email });
            });
            return customer;
        }

            Task<bool> ICustomerRepository.DeleteCustomer(int Id)
             {
                var customer = dictionary.GetValueOrDefault(Id);
                if (customer == null)
                {
                    return Task.FromResult(false);
                }
                dictionary.Remove(Id);
                return Task.FromResult(true);
            }

        public  List<Customer> GetAllCustomers()
        {

            return  dictionary.Values.ToList();

        }

        public async Task<Models.Domain.Customer?> GetCustomer(int Id)
        {
            var customer1 = dictionary.Values.FirstOrDefault(c => c.Id == Id);
            await Task.Run(() =>
            {
                var customer=dictionary.GetValueOrDefault(Id);
            });
            if (customer1 == null)
                return null;
            else
                return (Customer?)customer1;
        }

        public async Task<Customer?> UpdateCustomer(Customer customer)
        {
            var customer1 = dictionary.Values.FirstOrDefault(c => c.Id == customer.Id);
            if (customer1 == null)
                return null;
            await Task.Run(() =>
            {
                if (customer1 != null)
                {
                    customer1.CustName = customer.CustName;
                    customer1.CustAge = customer.CustAge;
                }
                
            });
            return customer1;
        }

    }
}
