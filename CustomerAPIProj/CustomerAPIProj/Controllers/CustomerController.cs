using CustomerAPIProj.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Customer = CustomerAPIProj.Models.Domain.Customer;

namespace CustomerAPIProj.Controllers
{

    [ApiController]
    public class CustomerController : Controller
    {
        public readonly ICustomer _services;
        public CustomerController(ICustomer services)
        {
            _services = services;
        }
        [HttpGet]
        [Route("api/Customer/GetAllCustomersAsynch")]
        public async Task<IActionResult> GetAllCustomersAsynch()
        {
            var customers = _services.GetAllCustomers();
            if (customers==null)
                return NotFound();
            else
                return Ok();
        }
        
        [HttpGet]
        [Route("api/Customer/GetCustomersAsynch{id:int}")]
        public async Task<IActionResult> GetCustomersAsynch(int id)
        {
            var response = await _services.GetCustomer(id);
            if (response == null)
                return NotFound();
            else
                return Ok(response);
        }
        [HttpPost]
        [Route("api/Customer/AddCustomerAsync")]
        public async Task<IActionResult> AddCustomerAsync(Customer addCustomerRequest)
        {
            return Ok(await _services.AddCustomer(addCustomerRequest));
        }
        [HttpDelete]
        [Route("api/Customer/DeleteCustomerAsync/{id:int}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var response = await _services.GetCustomer(id);
            if (response == null)
                return NotFound();
            else
                _services.DeleteCustomer(id);
            return Ok();
        }


        [HttpPut]
        [Route("api/Customer/UpdateCustomerAsync")]
        public async Task<IActionResult> UpdateCustomerAsync(Customer customer)
        {
            var response = await _services.GetCustomer(customer.Id);
            if (response != null)
                return Ok(response);
            else
                return NotFound();
        }
        
        //#region private methods
        //private bool ValidateAddCustomerAsync(Models.DTO.AddCustomerRequest addCustomerRequest)
        //{
        //    if(addCustomerRequest==null)
        //    {
        //        ModelState.AddModelError(nameof(addCustomerRequest), $"Add Customer Request is required");
        //        return false;
        //    }
        //    if(string.IsNullOrWhiteSpace(addCustomerRequest.CustName))
        //    {
        //        ModelState.AddModelError(nameof(addCustomerRequest.CustName), $"{nameof(addCustomerRequest.CustName)} cannot be null or empty");
        //        return false;
        //    }
        //    if(ModelState.ErrorCount>0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //#endregion
    }

}
