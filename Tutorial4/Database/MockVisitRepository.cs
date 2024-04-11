using Tutorial4.Models;

namespace  Tutorial4.Database;

    public class MockVisitRepository
    {
        public List<Visit> Visits { get; set; } = new List<Visit>
        {
            new Visit
            {
                Id = 1, VisitDate = DateTime.Now,
                Animal = new Animal { Id = 1, FirstName = "Burek", Category = "Dog", Weight = 15.5, FurColor = "Brown" },
                Description = "Regular checkup", Price = 50.0m
            },
            new Visit
            {
                Id = 2, VisitDate = DateTime.Now.AddDays(-10),
                Animal = new Animal { Id = 2, FirstName = "Mruczek", Category = "Cat", Weight = 5.2, FurColor = "Gray" },
                Description = "Vaccination", Price = 35.0m
            }
        };
        

        public IEnumerable<Visit> GetVisitsByAnimalId(int animalId)
        {
            return Visits.Where(v => v.Animal.Id == animalId);
        }

        public void AddVisit(Visit visit)
        {
            // Generowanie unikalnego Id dla wizyty
            int newId = Visits.Count > 0 ? Visits.Max(v => v.Id) + 1 : 1;
            visit.Id = newId;
            Visits.Add(visit);
        }
    }
