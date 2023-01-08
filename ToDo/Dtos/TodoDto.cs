using System.ComponentModel.DataAnnotations;

namespace ToDo.Dtos;

public class TodoDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DateTimeExpiry { get; set; }
    [Range(0.0,100.0,ErrorMessage = "The number should be between 0 and 100")]
    public double? PercentComplete { get; set; }
    public bool? isDone { get; set; }
}