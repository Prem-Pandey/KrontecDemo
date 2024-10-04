using Microsoft.AspNetCore.Mvc;
using KrontecDemo.Models;
using KrontecDemo.Services;

namespace KrontecDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerApiController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerApiController> _logger;

        public CustomerApiController(CustomerService customerService, ILogger<CustomerApiController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customers."); // Log the error
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            try
            {
                var customer = _customerService.GetCustomer(id);
                if (customer == null)
                    return NotFound();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the customer."); // Log the error
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _customerService.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the customer.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest("Customer ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _customerService.UpdateCustomer(customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the customer.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _customerService.GetCustomer(id);
                if (customer == null)
                    return NotFound();

                _customerService.DeleteCustomer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the customer.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
