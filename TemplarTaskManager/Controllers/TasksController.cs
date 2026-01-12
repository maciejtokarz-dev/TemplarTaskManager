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

        // GET: api/Tasks
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_context.TodoItems.ToList());
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var znalezione_zadanie = _context.TodoItems.Find(id); 
            if (znalezione_zadanie == null)
            {
                return NotFound();
            }
            return Ok(znalezione_zadanie);
        }

        // POST: api/Tasks
        [HttpPost]
        public IActionResult CreateTask([FromBody] TodoItem noweZadanie)
        {
            // Nie ustawiamy ID ręcznie! Baza zrobi to sama.
            _context.TodoItems.Add(noweZadanie);

            // KLUCZOWE: Zapis do bazy
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetTask),
                new { id = noweZadanie.Id }, // Tutaj noweZadanie.Id ma już wartość nadaną przez bazę
                noweZadanie
            );
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TodoItem zaktualizowaneZadanie)
        {
            if (id != zaktualizowaneZadanie.Id)
            {
                return BadRequest("ID w URL musi pasować do ID w ciele żądania");
            }

            var istniejaceZadanie = _context.TodoItems.Find(id);

            if (istniejaceZadanie == null)
            {
                return NotFound();
            }

            // Aktualizacja pól
            istniejaceZadanie.Opis = zaktualizowaneZadanie.Opis;
            istniejaceZadanie.isCompleted = zaktualizowaneZadanie.isCompleted;

            // KLUCZOWE:  Zapis do bazy
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var zadanieDoUsuniecia = _context.TodoItems.Find(id);
            if (zadanieDoUsuniecia == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(zadanieDoUsuniecia);

            // KLUCZOWE: Zapis do bazy
            _context.SaveChanges();

            return NoContent();
        }
    }
}
