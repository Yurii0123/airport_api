using System.ComponentModel.DataAnnotations;
using Airport.Core.Validation;

namespace Airport.Core.DTO;

public class CreatePassengerRequest
{
    public int? AirportId { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Surname { get; set; }

    public string? Email { get; set; }

    [Required]
    [PassportNumber]
    public required string PassportNumber { get; set; }

    public string? Phone { get; set; }
}
