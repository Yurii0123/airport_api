namespace Airport.Core.DTO;

public class AirportDto
{
    public int Id { get; set; }

    public required string Code { get; set; }

    public required string Name { get; set; }
}
