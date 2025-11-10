using Microsoft.AspNetCore.Mvc;
using Airport.Core.DTO;
using Airport.Core.Interfaces;

namespace Airport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengersController(IPassengerService passengerService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await passengerService.GetAllAsync(token);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken token)
        {
            var result = await passengerService.GetByIdAsync(id, token);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePassengerRequest request, CancellationToken token)
        {
            var created = await passengerService.AddAsync(request, token);
            return Ok(created.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePassengerRequest request, CancellationToken token)
        {
            await passengerService.UpdateAsync(id, request, token);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            await passengerService.DeleteAsync(id, token);
            return NoContent();
        }
    }
}
