using CustomerAPIProj.Data;
using CustomerAPIProj.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPIProj.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext ncustomerDBContext;
        public CustomerRepository(CustomerDBContext ncustomerDBContext)
        {
            this.ncustomerDBContext = ncustomerDBContext;
        }

        public async Task<Customer> AddAsynch(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            await ncustomerDBContext.AddAsync(customer);
            await ncustomerDBContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteAsync(Guid Id)
        {
            var customer = await ncustomerDBContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);
            if(customer==null)
            {
                return null;
            }
            ncustomerDBContext.Customers.Remove(customer);
            await ncustomerDBContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await ncustomerDBContext.Customers.ToListAsync();

        }

        public async Task<Customer>GetAsync(Guid Id)
        {
           return await ncustomerDBContext.Customers.FirstOrDefaultAsync(x=>x.Id==Id);
        }

        public async Task<Customer> UpdateAsynch(Guid Id, Customer customer)
        {
            var existingcustomer=await ncustomerDBContext.Customers.FirstOrDefaultAsync(x=>x.Id== Id);
            if(existingcustomer == null)
            {
                return null;
            }
            existingcustomer.CustName = customer.CustName;
            existingcustomer.CustAge = customer.CustAge;
            existingcustomer.Email = customer.Email;
            await ncustomerDBContext.SaveChangesAsync();
            return existingcustomer;
        }
    }
}
