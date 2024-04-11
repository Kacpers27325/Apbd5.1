using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly MockDb _animalRepository;


        public AnimalsController(MockDb animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            var animals = _animalRepository.GetAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = _animalRepository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _animalRepository.AddAnimal(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal)
        {
            _animalRepository.UpdateAnimal(id, animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _animalRepository.DeleteAnimal(id);
            return NoContent();
        }
    }
}