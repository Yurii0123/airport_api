using Microsoft.EntityFrameworkCore;
using Airport.Core.Entities;

namespace Airport.Core.Interfaces;

public interface IAirportDbContext
{
    DbSet<AirportEntity> Airports { get; set; }

    DbSet<PassengerEntity> Passengers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken token = default);
}
