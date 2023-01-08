using System.Data;
using ToDo.Models;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ToDo.Dtos;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services;

public class TodoService : ITodoService
{
    private readonly IDbConnection _dbConnection;
    public TodoService(IDbConnection connection)
    {
        _dbConnection = connection;
    }
    public async Task<List<Todo>> GetAllTodos()
    {
        var result = await _dbConnection.SelectAsync<Todo>();
        return result;
    }

    public async Task<Todo> GetTodoById(long id)
    {
        var result = await _dbConnection.SelectAsync<Todo>(todo => todo.Id == id);
        return result.First();
    }

    public async Task<List<Todo>> GetTodoForToday()
    { 
        var fromDate = DateTime.Now.Date;
        var toDate = fromDate.AddDays(1);
        var result = await _dbConnection.SelectAsync<Todo>(x => x.DateTimeExpiry >= fromDate && x.DateTimeExpiry < toDate);
        
        return result;
    }

    public async Task<List<Todo>> GetTodoForNextDay()
    {
        var fromDate = DateTime.Now.Date.AddDays(1);
        var toDate = fromDate.AddDays(2);
        var result = await _dbConnection.SelectAsync<Todo>(x => x.DateTimeExpiry >= fromDate && x.DateTimeExpiry < toDate);
        
        return result;
    }

    public async Task<List<Todo>> GetTodoForCurrentWeek()
    {
        var dayOfWeek = (int)DateTime.Now.Date.DayOfWeek == 0 ? 7 : (int)DateTime.Now.Date.DayOfWeek;
        var fromDate = DateTime.Now.Date.AddDays(-dayOfWeek);
        var toDate = fromDate.AddDays(7);

        var result = await _dbConnection.SelectAsync<Todo>(x => x.DateTimeExpiry >= fromDate && x.DateTimeExpiry < toDate);
        
        return result;
    }

    public async Task CreateTodo(TodoDto todoDto)
    {
        Todo todo = new Todo();
        Map(todo,todoDto);
        await _dbConnection.InsertAsync(todo);
    }

    public async Task UpdateTodo(long id, TodoDto dto)
    {
        var todos =  await _dbConnection.SelectAsync<Todo>(t => t.Id == id);
        var todo = todos.First();
        Map(todo, dto);
        await _dbConnection.UpdateAsync(todo);
    }

    public async Task DeleteTodo(long id)
    {
        await _dbConnection.DeleteAsync<Todo>(todo => todo.Id == id);
    }

    public async Task SetTodoPercentComplete(long id, double percentComplete)
    {
        var todos = await _dbConnection.SelectAsync<Todo>(todo => todo.Id == id);
        var todo = todos.First();
        todo.PercentComplete = percentComplete;
        await _dbConnection.UpdateAsync(todo);
    }

    public async Task MarkTodoAsDone(long id)
    {
        var todos = await _dbConnection.SelectAsync<Todo>(todo => todo.Id == id);
        var todo = todos.First();
        todo.isDone = true;
        await _dbConnection.UpdateAsync(todo);
    }
    
    //assign a value if dto value is not null
    private void  Map(Todo todo, TodoDto dto)
    {
        todo.Title = dto.Title ?? todo.Title;
        todo.Description = dto.Description ?? todo.Description;
        todo.DateTimeExpiry = dto.DateTimeExpiry ?? todo.DateTimeExpiry;
        todo.PercentComplete = dto.PercentComplete ?? todo.PercentComplete;
        todo.isDone = dto.isDone ?? todo.isDone;
    }
}