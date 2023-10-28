namespace Domain.DTOs;

public class PostSearchParametersDto
{
    public int? PostId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    public PostSearchParametersDto(int? postId, string? title, string? body)
    {
        PostId = postId;
        Title = title;
        Body = body;
    }
}