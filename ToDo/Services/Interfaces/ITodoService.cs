using ToDo.Dtos;
using ToDo.Models;

namespace ToDo.Services.Interfaces;

public interface ITodoService
{
    public Task<List<Todo>> GetAllTodos();
    public Task<Todo> GetTodoById(long id);
    public Task<List<Todo>> GetTodoForToday();
    public Task<List<Todo>> GetTodoForNextDay();
    public Task<List<Todo>> GetTodoForCurrentWeek();
    public Task CreateTodo(TodoDto todo);
    public Task UpdateTodo(long id, TodoDto todo);
    public Task DeleteTodo(long id);
    public Task SetTodoPercentComplete(long id, double percentComplete);
    public Task MarkTodoAsDone(long id);
}