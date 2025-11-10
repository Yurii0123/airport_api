namespace Airport.Core.Entities;

public class PassengerEntity
{
    public int Id { get; set; }

    public int? AirportId { get; set; }

    public required string Name { get; set; }

    public required string Surname { get; set; }

    public string? Email { get; set; }

    public required string PassportNumber { get; set; }

    public string? Phone { get; set; }

    public virtual AirportEntity? Airport { get; set; }
}
