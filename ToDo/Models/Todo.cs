using ServiceStack.DataAnnotations;

namespace ToDo.Models;

public class Todo
{
    [AutoIncrement]
    public long Id { get; set; }
    public DateTime DateTimeExpiry { get; set; }
    [Required] 
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    [Default(0.0)]
    public double PercentComplete { get; set; }
    public bool isDone { get; set; }
}