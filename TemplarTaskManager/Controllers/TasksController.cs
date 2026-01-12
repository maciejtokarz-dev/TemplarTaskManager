using Microsoft.AspNetCore.Mvc;
using TemplarTaskManager.Models;
using TemplarTaskManager.Data;

namespace TemplarTaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getTasks()
        {
            return Ok(_context.TodoItems.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var znalezione_zadanie = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (znalezione_zadanie == null)
            {
                return NotFound();
            }
            return Ok(znalezione_zadanie);

        }

        [HttpPost]
        public IActionResult CreateTask([FromBody]TodoItem noweZadanie)
        {
            int maxId = _context.TodoItems.Any() ? _context.TodoItems.Max(z => z.Id): 0;
            noweZadanie.Id = maxId + 1;
            _context.TodoItems.Add(noweZadanie);
            return CreatedAtAction(
                nameof(GetTask),
                new {id = noweZadanie.Id},
                noweZadanie
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TodoItem zaktualizowaneZadanie)
        {
            if(zaktualizowaneZadanie.Id != id)
            {
                return BadRequest("Podaj zgadzające się Id");
            }
            var znalezioneZadanie = _context.TodoItems.FirstOrDefault(x => x.Id == id);

            if (znalezioneZadanie == null)
            {
                return NotFound();
            }

            znalezioneZadanie.Opis = zaktualizowaneZadanie.Opis;
            znalezioneZadanie.isCompleted = zaktualizowaneZadanie.isCompleted;
            
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var znalezioneZadanie = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if(znalezioneZadanie == null)
            {
                return NotFound();
            }
            _context.TodoItems.Remove(znalezioneZadanie);
            return NoContent();
        }//test commita
        
    }
}
