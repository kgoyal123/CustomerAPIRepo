using CustomerAPIProj.Validators;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace CustomerAPIProj.Models.Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustName { get; set; }
        [Required]        
        public int CustAge { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
