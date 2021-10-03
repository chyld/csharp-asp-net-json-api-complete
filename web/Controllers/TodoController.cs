using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace web
{
  public class Dog { public string Name; }
  [ApiController]
  [Route("todos")]
  public class TodoController : ControllerBase
  {
    private ITodoRepository _repository;

    public TodoController(ITodoRepository repository)
    {
      _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoDto todoDto)
    {
      // This action will not run unless
      // 1. The JSON gets deserialized into the DTO
      // 2. Validation checks on the DTO are good

      var todo = new Todo(todoDto);
      await _repository.AddAsync(todo);
      await _repository.SaveAsync();

      // 1. GetOne is the name of an Action/function
      // 2. Argument (2) is the Id that will show up in the response location header
      // 3. Argument (3), todo, is the object that will be returned in the response body
      return CreatedAtAction("GetOne", new { todo.Id }, todo);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
      // 1. id fails validation, returns (400 Bad Request)
      // 2. id is valid but not found, returns (204 No Content)
      // 3. id is valid and is found, returns (200 OK)

      var todo = await _repository.GetByIdAsync(id);
      return Ok(todo);
    }
  }
}
