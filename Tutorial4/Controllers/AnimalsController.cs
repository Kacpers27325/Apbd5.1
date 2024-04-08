using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;
using Tutorial4.Repositories;

namespace Tutorial4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly MockDb _animalRepository;
        private readonly MockVisitRepository _visitRepository;

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
        
        
        [HttpGet("{animalId}/visits")]
        public IActionResult GetVisitsForAnimal(int animalId)
        {
            var animal = _animalRepository.GetAnimalById(animalId);
            if (animal == null)
            {
                return NotFound($"Zwierzę o Id {animalId} nie istnieje.");
            }

            // Pobieramy wizyty dla danego zwierzęcia z repozytorium wizyt
            var visits = _visitRepository.GetVisitsByAnimalId(animalId);

            return Ok(visits);
        }

        [HttpPost("{animalId}/visits")]
        public IActionResult AddVisitForAnimal(int animalId, Visit visit)
        {
            var animal = _animalRepository.GetAnimalById(animalId);
            if (animal == null)
            {
                return NotFound($"Zwierzę o Id {animalId} nie istnieje.");
            }

            // Ustawiamy zwierzę dla nowej wizyty
            visit.Animal = animal;

            // Dodajemy nową wizytę do repozytorium wizyt
            _visitRepository.AddVisit(visit);

            return CreatedAtAction(nameof(GetVisitsForAnimal), new { animalId = animalId }, visit);
        }
        
        
    }
}