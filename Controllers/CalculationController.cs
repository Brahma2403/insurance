using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using insuranceWebApi.models;
//using insuranceWebApi.Migrations;
namespace insuranceWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly InsuranceApiDbContext _context;

        public CalculationController(InsuranceApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Route("GetAllCalculations")]
        public ActionResult Get()
        {
            try
            {
                var calculation = _context.Calculations.ToList();
                if (calculation.Count == 0)
                {
                    return NotFound("No calculations found.");
                }
                return Ok(calculation);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        //[Route("GetCalculationById/{id}")] //Attribute Routing
        public ActionResult Get(int id)
        {
            try
            {
                var cal = _context.Calculations.Find(id);
                if (cal == null)
                {
                    return NotFound($"Calculation with ID {id} not found.");
                }
                return Ok(cal);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error:{ex.Message}");
            }
        }
    }
}