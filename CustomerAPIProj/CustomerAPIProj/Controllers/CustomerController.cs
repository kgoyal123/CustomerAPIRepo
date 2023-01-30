using AutoMapper;
using CustomerAPIProj.Models.Domain;
using CustomerAPIProj.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPIProj.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository,IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = customerRepository.GetAll();
            //return DTO customers
            //var customersDTO = new List<Models.DTO.Customer>();
            //customers.ToList().ForEach(customer =>
            //{
            //    var customerDTO = new Models.DTO.Customer()
            //    {
            //        Id=customer.Id,
            //        CustName=customer.CustName,
            //        CustAge=customer.CustAge,
            //        Email=customer.Email
            //    };
            //    customersDTO.Add(customerDTO);
            //});
            return Ok(customersDTO);
        }
    }
}
