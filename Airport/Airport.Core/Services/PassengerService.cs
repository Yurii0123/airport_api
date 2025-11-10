using Microsoft.EntityFrameworkCore;
using Airport.Core.DTO;
using Airport.Core.Entities;
using Airport.Core.Interfaces;
using Airport.Core.Validation;

namespace Airport.Core.Services;

public class PassengerService(IAirportDbContext context) : IPassengerService
{
    public async Task<IEnumerable<PassengerDto>> GetAllAsync(CancellationToken token)
    {
        var passengers = await context.Passengers
            .Include(p => p.Airport)
            .AsNoTracking()
            .ToListAsync(token);

        return passengers.Select(p => new PassengerDto
        {
            Id = p.Id,
            AirportName = p.Airport?.Name,
            Name = p.Name,
            Surname = p.Surname,
            Email = p.Email,
            PassportNumber = p.PassportNumber,
            Phone = p.Phone
        });
    }

    public async Task<PassengerDto?> GetByIdAsync(int id, CancellationToken token)
    {
        var p = await context.Passengers
            .Include(p => p.Airport)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, token);

        if (p == null) return null;

        return new PassengerDto
        {
            Id = p.Id,
            AirportName = p.Airport?.Name,
            Name = p.Name,
            Surname = p.Surname,
            Email = p.Email,
            PassportNumber = p.PassportNumber,
            Phone = p.Phone
        };
    }
    public async Task<PassengerDto> AddAsync(CreatePassengerRequest request, CancellationToken token)
    {
        if (!PassportValidator.IsValid(request.PassportNumber))
            throw new ArgumentException("Invalid passport number format.", nameof(request.PassportNumber));

        if (request.AirportId.HasValue)
        {
            await ValidateAirportAsync(request.AirportId.Value, token);
        }

        var passenger = new PassengerEntity
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            PassportNumber = request.PassportNumber.ToUpper(),
            Phone = request.Phone,
            AirportId = request.AirportId.HasValue ? request.AirportId : null,
        };

        context.Passengers.Add(passenger);
        await context.SaveChangesAsync(token);

        return new PassengerDto
        {
            Id = passenger.Id,
            AirportName = passenger.Airport?.Name,
            Name = passenger.Name,
            Surname = passenger.Surname,
            Email = passenger.Email,
            PassportNumber = passenger.PassportNumber,
            Phone = passenger.Phone,
        };
    }

    public async Task UpdateAsync(int id, UpdatePassengerRequest request, CancellationToken token)
    {
        if (!PassportValidator.IsValid(request.PassportNumber))
            throw new ArgumentException("Invalid passport number format.", nameof(request.PassportNumber));

        var passenger = await context.Passengers
            .Include(p => p.Airport)
            .FirstOrDefaultAsync(p => p.Id == id, token);

        if (passenger == null)
            throw new KeyNotFoundException($"Passenger {id} not found");

        if (request.AirportId.HasValue)
        {
            await ValidateAirportAsync(request.AirportId.Value, token);
        }

        passenger.Name = request.Name;
        passenger.Surname = request.Surname;
        passenger.Email = request.Email;
        passenger.PassportNumber = request.PassportNumber.ToUpper();
        passenger.Phone = request.Phone;
        passenger.AirportId = request.AirportId;

        await context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(int id, CancellationToken token)
    {
        var passenger = await context.Passengers.FindAsync(id, token);
        if (passenger == null) return;

        context.Passengers.Remove(passenger);
        await context.SaveChangesAsync(token);
    }

    private async Task ValidateAirportAsync(int airportId, CancellationToken token)
    {
        var airport = await context.Airports.FindAsync(airportId, token);
        if (airport == null)
            throw new InvalidOperationException($"Airport {airportId} not found");

    }
}
