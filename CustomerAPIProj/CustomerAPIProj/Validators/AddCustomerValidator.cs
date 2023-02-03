using CustomerAPIProj.Models.DTO;
using FluentValidation;

namespace CustomerAPIProj.Validators
{
    public class AddCustomerValidator : AbstractValidator<Customer>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.CustName).NotEmpty();
            RuleFor(x => x.CustAge).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
