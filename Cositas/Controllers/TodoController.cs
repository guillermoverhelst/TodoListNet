using Cositas.DataAccess;
using Cositas.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cositas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly Context _context;
        private readonly TodoFactoryProvider _factoryProvider;

        public TodoController(Context context, TodoFactoryProvider factoryProvider) {
            _context = context;
            _factoryProvider = factoryProvider;
        }
        [HttpPost("createWithType")]
        public IActionResult CreateWithType(string type, string name)
        {
            try
            {
                var factory = _factoryProvider.GetFactory(type);
                var newTodo = factory.CreateTodo(name);
                _context.TodoItems.Add(newTodo);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = newTodo.Id }, newTodo);
            }
            catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task <IActionResult> GetAll() { 
            var todos = await _context.TodoItems.ToListAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var todo = _context.TodoItems.Find(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpGet("Totype")]
        public IActionResult GetByType([FromQuery]string type)
        {
            var todo = _context.TodoItems.Where(t => t.Type.ToLower() == type.ToLower()).ToList();
            return Ok(todo);
        }

        [HttpPut("{id}/completed")]
        public IActionResult TodoIsCompleted(int id, [FromBody] bool iscomplete) { 
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            todo.IsComplete = iscomplete;
            _context.SaveChanges();
            return Ok(todo);
        }
    }
}
