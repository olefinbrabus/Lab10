using Lab10.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IBaseRepository<Animal> _animalRepository;

        public AnimalController(IBaseRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public IEnumerable<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var animal = _animalRepository.Get(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            _animalRepository.Create(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            var existingAnimal = _animalRepository.Get(id);
            if (existingAnimal == null)
            {
                return NotFound();
            }

            _animalRepository.Update(animal);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var existingAnimal = _animalRepository.Get(id);
            if (existingAnimal == null)
            {
                return NotFound();
            }

            _animalRepository.Delete(id);
            return NoContent();
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AviaryController : ControllerBase
    {
        private readonly IBaseRepository<Aviary> _aviaryRepository;

        public AviaryController(IBaseRepository<Aviary> aviaryRepository)
        {
            _aviaryRepository = aviaryRepository;
        }

        [HttpGet]
        public IEnumerable<Aviary> GetAll()
        {
            return _aviaryRepository.GetAll();
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var aviary = _aviaryRepository.Get(id);
            if (aviary == null)
            {
                return NotFound();
            }
            return Ok(aviary);
        }

        [HttpPost]
        public IActionResult Create(Aviary aviary)
        {
            _aviaryRepository.Create(aviary);
            return CreatedAtAction(nameof(Get), new { id = aviary.Id }, aviary);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, Aviary aviary)
        {
            if (id != aviary.Id)
            {
                return BadRequest();
            }

            var existingAviary = _aviaryRepository.Get(id);
            if (existingAviary == null)
            {
                return NotFound();
            }

            _aviaryRepository.Update(aviary);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var existingAviary = _aviaryRepository.Get(id);
            if (existingAviary == null)
            {
                return NotFound();
            }

            _aviaryRepository.Delete(id);
            return NoContent();
        }
    }
}
