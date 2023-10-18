using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDTO
{
    public string Username { get; set; }
    public string Title { get; set; }
    public string body { get; set; }

    public PostCreationDTO(string username, string title, string body)
    {
        Username = username;
        Title = title;
        this.body = body;
    }
}