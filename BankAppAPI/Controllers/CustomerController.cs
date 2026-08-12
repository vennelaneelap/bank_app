using BankAppAPI.Models;
using BankAppAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        // GET: api/customers
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return Ok(_service.GetAllCustomers());
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            Customer? customer = _service.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            Customer createdCustomer =
                _service.CreateCustomer(customer);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdCustomer.Id },
                createdCustomer
            );
        }

        // PUT: api/customers/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            bool updated =
                _service.UpdateCustomer(id, customer);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/customers/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted =
                _service.DeleteCustomer(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}