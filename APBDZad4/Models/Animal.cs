using System.ComponentModel.DataAnnotations;

namespace APBDZad4.Models;

public class Animal
{
    [Key] [Required]
    public required int IdAnimal { get; init; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Category { get; set; }

    [Required]
    public required float Mass { get; set; }

    [Required]
    public required string FurColor { get; set; }
}