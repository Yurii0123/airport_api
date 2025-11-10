using Airport.Core.DTO;

namespace Airport.Core.Interfaces;

public interface IPassengerService
{
    Task<IEnumerable<PassengerDto>> GetAllAsync(CancellationToken token);

    Task<PassengerDto?> GetByIdAsync(int id, CancellationToken token);

    Task<PassengerDto> AddAsync(CreatePassengerRequest request, CancellationToken token);

    Task UpdateAsync(int id, UpdatePassengerRequest request, CancellationToken token);

    Task DeleteAsync(int id, CancellationToken token);
}
