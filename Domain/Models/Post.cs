using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
   [Key]
    public int Id { get; set; }
    public AuthenticationUser Owner { get; set; }
    public string Title { get; set; }
    public string body { get; set; }
    
}