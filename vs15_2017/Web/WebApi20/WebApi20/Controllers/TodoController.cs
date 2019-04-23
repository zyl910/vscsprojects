using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi20.Models;

namespace WebApi20.Controllers
{
	[Route("api/[controller]")]
	//[ApiController]
	public class TodoController : Controller {
		private readonly TodoContext _context;

		public TodoController(TodoContext context) {
			_context = context;

			if (_context.TodoItems.Count() == 0) {
				// Create a new TodoItem if collection is empty,
				// which means you can't delete all TodoItems.
				_context.TodoItems.Add(new TodoItem { Name = "Item1" });
				_context.SaveChanges();
			}
		}

		// GET: api/Todo
		[HttpGet]
		public async Task<IEnumerable<TodoItem>> GetTodoItems() {
			return await _context.TodoItems.ToListAsync();
		}

		// GET: api/Todo/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTodoItem(long id) {
			var todoItem = await _context.TodoItems.FindAsync(id);

			if (todoItem == null) {
				return NotFound();
			}

			return Json(todoItem);
		}

		// POST: api/Todo
		[HttpPost]
		public async Task<IActionResult> PostTodoItem(TodoItem item) {
			_context.TodoItems.Add(item);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
		}

		// PUT: api/Todo/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTodoItem(long id, TodoItem item) {
			if (id != item.Id) {
				return BadRequest();
			}

			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/Todo/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTodoItem(long id) {
			var todoItem = await _context.TodoItems.FindAsync(id);

			if (todoItem == null) {
				return NotFound();
			}

			_context.TodoItems.Remove(todoItem);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
