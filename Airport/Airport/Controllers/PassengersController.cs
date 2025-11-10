using Airport.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengersController : ControllerBase
    {
        private readonly ILogger<PassengersController> _logger;

        public PassengersController(ILogger<PassengersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Passenger> Get()
        {
            return [
                new Passenger() {
                    Id = 1,
                    Name = "Test"
            } ];
        }
    }
}
