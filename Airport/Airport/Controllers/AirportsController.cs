using Microsoft.AspNetCore.Mvc;
using Airport.Core.Interfaces;

namespace Airport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController(IAirportService airportService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await airportService.GetAllAsync(token);
            return Ok(result);
        }
    }
}
