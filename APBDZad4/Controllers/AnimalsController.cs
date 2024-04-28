using APBDZad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBDZad4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> Animals =
    [
        new Animal { IdAnimal = 1, Name = "Stefan", Category = "kot", Mass = 5.4f, FurColor = "szary" },
        new Animal { IdAnimal = 2, Name = "Bartosz", Category = "fretka", Mass = 1.3f, FurColor = "czarny" },
        new Animal { IdAnimal = 3, Name = "Azor", Category = "pies", Mass = 12.4f, FurColor = "biały" }
    ];

    private static readonly List<Visit> Visits =
    [
        new Visit
        {
            IdVisit = 1, IdAnimal = 3, Date = new DateTime(2023, 2, 12), Description = "Szczepienie na wściekliznę",
            Price = 100
        },
        new Visit
        {
            IdVisit = 2, IdAnimal = 1, Date = new DateTime(2021, 3, 30), Description = "Odrobaczanie", Price = 70.5f
        },
        new Visit
        {
            IdVisit = 3, IdAnimal = 1, Date = new DateTime(2022, 5, 20), Description = "Wyciąganie klescza",
            Price = 10.3f
        }
    ];

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal == null) return NotFound($"Nie znaleziono zwierzęcia o podanym id: {id}");
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        Animals.Add(animal);
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToUpdate = Animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animalToUpdate == null) return NotFound($"Nie znaleziono zwierzęcia o podanym id: {id}");
        Animals.Remove(animalToUpdate);
        Animals.Add(animal);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal == null) return NotFound($"Nie znaleziono zwierzęcia o podanym id: {id}");

        Animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("{id:int}/visits")]
    public IActionResult GetVisits(int id)
    {
        var visits = Visits.FindAll(v => v.IdAnimal == id);
        if (visits.Count == 0) return NotFound($"Nie znaleziono wizyt zwierzęcia o podanym id: {id}");

        return Ok(visits);
    }

    [HttpPost("{id:int}/visits")]
    public IActionResult CreateVisit(int id, Visit visit)
    {
        visit.IdAnimal = id;
        return Created();
    }
}