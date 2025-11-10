using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Airport.Core.Interfaces;
using Airport.Core.Services;

namespace Airport.Data.Extensions;

public static class DataDbExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AirportDbContext>(options =>
        {
            options.UseInMemoryDatabase("AirportDb");
        });

        services.AddScoped<IAirportDbContext>(sp => sp.GetRequiredService<AirportDbContext>());

        services.AddScoped<IPassengerService, PassengerService>();
        services.AddScoped<IAirportService, AirportService>();

        return services;
    }
}