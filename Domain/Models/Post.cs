using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
   [Key]
    public int Id { get; set; }
    public AuthenticationUser Owner { get; private set; }
    public int OwnerId { get; set; }
    public string Title { get; set; }
    public string body { get; set; }


    public Post(int ownerId, string title, string body)
    {
        OwnerId = ownerId;
        Title = title;
        this.body = body;
    }
}