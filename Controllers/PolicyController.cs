using insuranceWebApi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace insuranceWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly InsuranceApiDbContext _context;

        public PolicyController(InsuranceApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Route("GetAllPolicyDetails")]
        public ActionResult Get()
        {
            try
            {
                var policy = _context.Policies.ToList();
                if (policy.Count == 0)
                {
                    return NotFound("No Policies found.");
                }
                return Ok(policy);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        //[Route("GetPolicyById/{id}")] //Attribute Routing
        public ActionResult Get(int id)
        {
            try
            {
                var pol = _context.Policies.Find(id);
                if (pol == null)
                {
                    return NotFound($"Policy with ID {id} not found.");
                }
                return Ok(pol);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error:{ex.Message}");
            }
        }

        //[HttpPost]
        //public IActionResult Insert([FromBody] Policy policy)
        //{
        //    if (policy == null)
        //    {
        //        return BadRequest("Invalid policy data.");
        //    }

        //    try
        //    {
        //        _context.Add(policy);
        //        _context.SaveChanges();
        //        return Ok("Policy created successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error: {ex.Message}");
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Policy policy)
        //{
        //    if (policy == null || policy.PolicyId != id)
        //    {
        //        return BadRequest("Invalid Policy data.");
        //    }

        //    try
        //    {
        //        var existingPolicy = _context.Policies.Find(id);
        //        if (existingPolicy == null)
        //        {
        //            return NotFound($"Policy with ID {id} not found.");
        //        }

        //        existingPolicy.PolicyType = policy.PolicyType;
        //        existingPolicy.CoverageAmount = policy.CoverageAmount;
        //        existingPolicy.PremiumAmount = policy.PremiumAmount;
        //        existingPolicy.ValidityStartDate = policy.ValidityStartDate;
        //        existingPolicy.ValidityEndDate = policy.ValidityEndDate;

        //        _context.SaveChanges();
        //        return Ok("Policy details updated successfully.");
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
        //        var po = _context.Policies.Find(id);
        //        if (po == null)
        //        {
        //            return NotFound($"Policy with ID {id} not found.");
        //        }

        //        _context.Policies.Remove(po);
        //        _context.SaveChanges();
        //        return Ok("Policy deleted successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error: {ex.Message}");
        //    }
        //}
    }
}
