using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDTO
{
    
    public string Username { get; }
    public string Title { get; set; }
    public string body { get; set; }

    public PostCreationDTO( string username, string title, string body)
    {
        this.Username = username;
       
        Title = title;
        this.body = body;
    }
}