namespace Domain.DTOs;

public class PostSearchParametersDto
{
    public string? Title { get; set; }
    public string? Body { get; set; }

    public PostSearchParametersDto(string? title, string? body)
    {
        Title = title;
        Body = body;
    }
}