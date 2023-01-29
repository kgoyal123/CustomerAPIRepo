using CustomerAPIProj.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPIProj.Data
{
    public class CustomerDBContext:DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
