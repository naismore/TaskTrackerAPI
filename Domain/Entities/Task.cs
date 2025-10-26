namespace Domain.Models;

public class Task
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
}