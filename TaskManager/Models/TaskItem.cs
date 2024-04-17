using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class TaskItem
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(1)]
    public string Title { get; set; }

    [Required]
    [MinLength(1)]
    public string Description { get; set; }

    public bool Completed { get; set; } = false;
}