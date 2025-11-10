namespace Airport.Core.DTO;

public class PassengerDto
{
    public int Id { get; set; }

    public string? AirportName { get; set; }

    public required string Name { get; set; }

    public required string Surname { get; set; }

    public string? Email { get; set; }

    public required string PassportNumber { get; set; }

    public string? Phone { get; set; }
}
