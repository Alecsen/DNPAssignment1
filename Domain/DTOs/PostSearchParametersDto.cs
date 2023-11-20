namespace Domain.DTOs;

public class PostSearchParametersDto
{
    public string? UserName { get; }
    public int? PostId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    public PostSearchParametersDto(string? userName,int? postId, string? title, string? body)
    {
        this.UserName = userName;
        PostId = postId;
        Title = title;
        Body = body;
    }
}