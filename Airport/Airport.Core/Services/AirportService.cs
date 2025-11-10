using Microsoft.EntityFrameworkCore;
using Airport.Core.DTO;
using Airport.Core.Interfaces;

namespace Airport.Core.Services;

public class AirportService(IAirportDbContext context) : IAirportService
{
    public async Task<IEnumerable<AirportDto>> GetAllAsync(CancellationToken token)
    {
        var airports = await context.Airports
              .AsNoTracking()
              .OrderBy(a => a.Name)
              .ToListAsync(token);

        return airports.Select(a => new AirportDto
        {
            Id = a.Id,
            Code = a.Code,
            Name = a.Name
        });
    }
}
