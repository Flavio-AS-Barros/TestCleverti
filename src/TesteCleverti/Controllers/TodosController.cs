using System.Collections.Generic;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using TesteCleverti.Models;
using TesteCleverti.Services;

namespace TesteCleverti.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/todo")]
    public class TodosController : Controller
    {
        private readonly TodoDbService _todoDbService;

        public TodosController(TodoDbService todoDbService)
        {
            _todoDbService = todoDbService;
        }

        [HttpGet("list-all-todo")]
        public ActionResult<List<Todo>> Get()
        {
            var todo = _todoDbService.Get();

            if (todo == null) return NotFound();

            return todo;

        }

        [HttpGet("get-todo-id/{id:length(24)}")]
        public ActionResult<Todo> Get(string id)
        {
            var todo = _todoDbService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }


        [HttpPost("new-todo")]
        public ActionResult<Todo> Create(Todo todo)
        {
            _todoDbService.Create(todo);

            return CreatedAtRoute("GetTodo", new { id = todo.TodoId.ToString() }, todo);
        }

        [HttpPut("update-todo/{id:length(24)}")]
        public IActionResult Update(string id, Todo todoIn)
        {
            var todo = _todoDbService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoDbService.Update(id, todoIn);

            return NoContent();
        }

        [HttpDelete("delete-todo{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var todo = _todoDbService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoDbService.Remove(todo.TodoId);

            return NoContent();
        }
    }
}