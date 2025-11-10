using Airport.Core.Entities;

namespace Airport.Data;

public static class SeedData
{
    public static void Initialize(AirportDbContext context)
    {
        if (!context.Airports.Any())
        {
            context.Airports.AddRange(
                new AirportEntity { Code = "MAD", Name = "Adolfo Suárez Madrid–Barajas Airport" },
                new AirportEntity { Code = "BCN", Name = "Barcelona–El Prat Airport" },
                new AirportEntity { Code = "AGP", Name = "Málaga Airport" },
                new AirportEntity { Code = "PMI", Name = "Palma de Mallorca Airport" },
                new AirportEntity { Code = "ALC", Name = "Alicante–Elche Airport" },
                new AirportEntity { Code = "LPA", Name = "Gran Canaria Airport" },
                new AirportEntity { Code = "TFS", Name = "Tenerife South Airport" },
                new AirportEntity { Code = "VLC", Name = "Valencia Airport" },
                new AirportEntity { Code = "SVQ", Name = "Seville Airport" },
                new AirportEntity { Code = "BIO", Name = "Bilbao Airport" },
                new AirportEntity { Code = "IBZ", Name = "Ibiza Airport" },
                new AirportEntity { Code = "MAH", Name = "Menorca Airport" },
                new AirportEntity { Code = "SCQ", Name = "Santiago de Compostela Airport" },
                new AirportEntity { Code = "OVD", Name = "Asturias Airport" },
                new AirportEntity { Code = "GRO", Name = "Girona–Costa Brava Airport" }
            );

            context.SaveChanges();
        }
    }
}