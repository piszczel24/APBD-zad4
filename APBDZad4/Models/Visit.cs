using System.ComponentModel.DataAnnotations;

namespace APBDZad4.Models;

public class Visit
{
    [Key]
    public required int IdVisit { get; set; }

    [Required]
    public required int IdAnimal { get; set; }

    [Required]
    public required DateTime Date { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required float Price { get; set; }
}