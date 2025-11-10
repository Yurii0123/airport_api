using Airport.Core.DTO;

namespace Airport.Core.Interfaces;

public interface IAirportService
{
    Task<IEnumerable<AirportDto>> GetAllAsync(CancellationToken token);
}
