using Microsoft.AspNetCore.Mvc;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using Proje.Services.Repositories;

namespace Proje.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpGet("GetAllCustomer")]
        public async Task<ActionResult<List<CustomerResponse>>> GetAllCustomer()
        {
            return await _customerRepo.GetAll();
        }
        [HttpGet("GetCustomerById")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerById(int id )
        {
            return Ok(await _customerRepo.GetById(id));
        }
        [HttpPost("AddCustomer")]
        public async Task<ActionResult<CustomerResponse>> AddCustomer(CustomerRequest request)
        {
            var item = await _customerRepo.Add(request);
            if(item != null) return Ok(item);
            return BadRequest();
        }
        [HttpPost("UpdateCustomer")]
        public async Task<ActionResult<CustomerResponse>> UpdateCustomer(CustomerRequest request, int id)
        {
            return Ok(await _customerRepo.UpdateById(request, id));
        }
        [HttpDelete("DeleteById")]
        public async Task<ActionResult<CustomerResponse>> DeleteCustomerById(int id)
        {
           return Ok(await _customerRepo.Delete(id));   
        }
        
    }
}
