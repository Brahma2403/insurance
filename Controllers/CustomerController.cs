using insuranceWebApi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace insuranceWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly InsuranceApiDbContext _context;

        public CustomerController(InsuranceApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Route("GetAllCUtomerDetails")]
        public IActionResult Get()
        {
            try
            {
                var customer = _context.Customers.ToList();
                if (customer.Count == 0)
                {
                    return NotFound("No Customers found.");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        //[Route("GetCustomerById/{id}")] //Attribute Routing
        public IActionResult Get(int id)
        {
            try
            {
                var cu = _context.Customers.Find(id);
                if (cu == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }
                return Ok(cu);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error:{ex.Message}");
            }
        }

        //[HttpPost]
        //public IActionResult Insert([FromBody]Customer customer)
        //{
        //    if (customer == null)
        //    {
        //        return BadRequest("Invalid Customer data.");
        //    }

        //    try
        //    {
        //        _context.Add(customer);
        //        _context.SaveChanges();
        //        return Ok("Customer created successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error: {ex.Message}");
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Customer customer)
        //{
        //    if (customer == null || customer.CustomerId != id)
        //    {
        //        return BadRequest("Invalid Customer data.");
        //    }

        //    try
        //    {
        //        var existingCustomer = _context.Customers.Find(id);
        //        if (existingCustomer == null)
        //        {
        //            return NotFound($"Customer with ID {id} not found.");
        //        }

        //        existingCustomer.Name = customer.Name;
        //        existingCustomer.Address = customer.Address;
        //        existingCustomer.Email = customer.Email;
        //        existingCustomer.Phone = customer.Phone;

        //        _context.SaveChanges();
        //        return Ok("Customer details updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error: {ex.Message}");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var c = _context.Customers.Find(id);
        //        if (c == null)
        //        {
        //            return NotFound($"Customer with ID {id} not found.");
        //        }

        //        _context.Customers.Remove(c);
        //        _context.SaveChanges();
        //        return Ok("Customer deleted successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error: {ex.Message}");
        //    }
        //}
    }
}
