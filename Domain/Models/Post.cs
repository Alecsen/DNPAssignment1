namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    public string body { get; set; }

    public Post(User owner, string title, string body)
    {
        Owner = owner;
        Title = title;
        this.body = body;
    }
}