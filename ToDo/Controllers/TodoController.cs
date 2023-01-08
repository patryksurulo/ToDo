using Microsoft.AspNetCore.Mvc;
using ToDo.Dtos;
using ToDo.Models;
using ToDo.Services.Interfaces;

namespace ToDo.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    [HttpGet]
    public async Task<List<Todo>> GetAllTodos()
    {
        return await _todoService.GetAllTodos();
    }

    [HttpGet("{id}")]
    public async Task<Todo> GetTodoById(long id)
    {
        return await _todoService.GetTodoById(id);
    }

    [HttpGet("today")]
    public async Task<List<Todo>> GetTodoForToday()
    {
        return await _todoService.GetTodoForToday();
    }

    [HttpGet("tomorrow")]
    public async Task<List<Todo>> GetTodoForNextDay()
    {
        return await _todoService.GetTodoForNextDay();
    }

    [HttpGet("week")]
    public async Task<List<Todo>> GetTodoForCurrentWeek()
    {
        return await _todoService.GetTodoForCurrentWeek();
    }

    [HttpPost]
    public async Task<ActionResult> CreateTodo(TodoDto todoDto)
    {
        if (todoDto.Title == null) return BadRequest("Field 'Title' cannot be null");
        if (todoDto.DateTimeExpiry == null) return BadRequest("Field 'DateTimeExpiry' cannot be null");

        await _todoService.CreateTodo(todoDto);

        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task UpdateTodo(long id, TodoDto todo)
    {
        await _todoService.UpdateTodo(id, todo);
    }

    [HttpDelete("{id}")]
    public async Task DeleteTodo(long id)
    {
        await _todoService.DeleteTodo(id);
    }

    [HttpPatch("{id}/complete")]
    public async Task SetTodoPercentComplete(long id, TodoDto todoDto)
    {
        if (todoDto.PercentComplete.HasValue)
        {
            await _todoService.SetTodoPercentComplete(id, todoDto.PercentComplete.Value);
        }
    }
    

    [HttpPatch("{id}/mark")]
    public async Task MarkTodoAsDone(long id)
    {
        await _todoService.MarkTodoAsDone(id);
    }
}