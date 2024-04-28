using APBDZad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBDZad4.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> Animals =
    [
        new Animal { IdAnimal = 1, Name = "Stefan", Category = "kot", Mass = 5.4f, FurColor = "szary" },
        new Animal { IdAnimal = 2, Name = "Bartosz", Category = "fretka", Mass = 1.3f, FurColor = "czarny" },
        new Animal { IdAnimal = 3, Name = "Azor", Category = "pies", Mass = 12.4f, FurColor = "biały" }
    ];

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimalById(int id)
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
    public IActionResult UpdateStudentById(int id, Animal animal)
    {
        var animalToUpdate = Animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animalToUpdate == null) return NotFound($"Nie znaleziono zwierzęcia o podanym id: {id}");
        Animals.Remove(animalToUpdate);
        Animals.Add(animal);

        return NoContent();
    }
}