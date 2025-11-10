namespace Airport.Core.Entities;

public class AirportEntity
{
    public int Id { get; set; }

    public required string Code { get; set; }

    public required string Name { get; set; }

    public IEnumerable<PassengerEntity> Passengers { get; set; } = new List<PassengerEntity>();
}
