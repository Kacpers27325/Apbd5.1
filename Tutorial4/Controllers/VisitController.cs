using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;
namespace Tutorial4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly MockVisitRepository _visitRepository;

        public VisitController(MockVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        
        [HttpGet]
        public IActionResult GetVisitsbyID(int id)
        {
            var animals = _visitRepository.GetVisitsByAnimalId(id);
            if (animals == null)
            {
                return NotFound();
            }
            return Ok(animals);
        }
        [HttpPost]
        public IActionResult AddVisit(Visit visit)
        {
            _visitRepository.AddVisit(visit);
            return CreatedAtAction(nameof(GetVisitsbyID), new { id = visit.Id }, visit);
        }
        
    }
}