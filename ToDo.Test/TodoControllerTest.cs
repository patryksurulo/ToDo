using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceStack;
using ToDo.Controllers;
using ToDo.Models;
using ToDo.Services.Interfaces;

namespace ToDo.Test;

public class TodoControllerTest
{
    private Mock<ITodoService> _mockTodoService = new Mock<ITodoService>();
    
    [Fact]
    public async void GetAllTodos_ShouldReturnAppropriateType()
    {
        //Arrange
        _mockTodoService.Setup(service => service.GetAllTodos()).ReturnsAsync(GetTestTodos());
        var controller = new TodoController(_mockTodoService.Object);
        
        //Act
        var result = await controller.GetAllTodos();
        
        //Assert
        Assert.IsType<List<Todo>>(result);
    }

    private List<Todo> GetTestTodos()
    {
        return new List<Todo>()
        {
            new Todo()
            {
                Id = 1, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 1, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 2, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 3, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 4, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 5, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 6, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 7, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 8, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 9, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            },
            new Todo()
            {
                Id = 10, Title = "Title", Description = "Description", isDone = false, PercentComplete = 12,
                DateTimeExpiry = new DateTime(2023, 5, 2, 20, 20, 20)
            }
        };
    }
}