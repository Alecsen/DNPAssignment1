namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public AuthenticationUser Owner { get; set; }
    public string Title { get; set; }
    public string body { get; set; }
    
}