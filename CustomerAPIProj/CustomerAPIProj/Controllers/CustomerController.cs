using AutoMapper;
using CustomerAPIProj.Models.Domain;
using CustomerAPIProj.Models.DTO;
using CustomerAPIProj.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;

namespace CustomerAPIProj.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsynch()
        {
            var customers = await customerRepository.GetAllAsync();
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
            var customersDTO = _mapper.Map<List<Models.DTO.Customer>>(customers);
            return Ok(customersDTO);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCustomersAsynch")]
        public async Task<IActionResult> GetCustomersAsynch(Guid id)
        {
            var customer = await customerRepository.GetAsync(id);
            var customerDTO = _mapper.Map<Models.DTO.Customer>(customer);
            if (customerDTO == null)
            {
                return NotFound();
            }
            return Ok(customerDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(Models.DTO.AddCustomerRequest addCustomerRequest)
        {
            if(!ValidateAddCustomerAsync(addCustomerRequest))
            {
                return BadRequest();
            }
            var customer = new Models.Domain.Customer()
            {
                CustName = addCustomerRequest.CustName,
                CustAge = addCustomerRequest.CustAge,
                Email = addCustomerRequest.Email
            };
            customer = await customerRepository.AddAsynch(customer);
            var customerDTO = new Models.DTO.Customer
            {
                Id = customer.Id,
                CustName = customer.CustName,
                CustAge = customer.CustAge,
                Email = customer.Email
            };
            return CreatedAtAction(nameof(GetCustomersAsynch), new { id = customerDTO.Id }, customerDTO);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            var customer = await customerRepository.DeleteAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDTO = new Models.DTO.Customer
            {
                Id = customer.Id,
                CustName = customer.CustName,
                CustAge = customer.CustAge,
                Email = customer.Email
            };
            return Ok(customerDTO);
        }
        [HttpPut]

        public async Task<IActionResult> UpdateCustomerAsync(Guid Id,Models.DTO.UpdateCustomerRequest updatecustomerrequest)
        {
            var customer = new Models.Domain.Customer()
            {
                CustName = updatecustomerrequest.CustName,
                CustAge = updatecustomerrequest.CustAge,
                Email = updatecustomerrequest.Email
            };
           customer= await customerRepository.UpdateAsynch(Id, customer);
           if(customer==null)
           {
                return NotFound();
           }
           var customerDTO = new Models.DTO.Customer
           {
                Id = customer.Id,
                CustName = customer.CustName,
                CustAge = customer.CustAge,
                Email = customer.Email
           };
            return Ok(customerDTO);
        }
        #region private methods
        private bool ValidateAddCustomerAsync(Models.DTO.AddCustomerRequest addCustomerRequest)
        {
            if(addCustomerRequest==null)
            {
                ModelState.AddModelError(nameof(addCustomerRequest), $"Add Customer Request is required");
                return false;
            }
            if(string.IsNullOrWhiteSpace(addCustomerRequest.CustName))
            {
                ModelState.AddModelError(nameof(addCustomerRequest.CustName), $"{nameof(addCustomerRequest.CustName)} cannot be null or empty");
                return false;
            }
            if(ModelState.ErrorCount>0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }

}
