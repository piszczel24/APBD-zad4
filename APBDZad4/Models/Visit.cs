namespace APBDZad4.Models;

public class Visit
{
    public required int IdVisit { get; set; }
    public required int IdAnimal { get; set; }
    public required DateTime Date { get; set; }
    public required string Description { get; set; }
    public required float Price { get; set; }
}