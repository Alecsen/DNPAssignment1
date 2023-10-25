using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }


    public Task<Post> CreateAsync(Post toPost)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(p => p.Id);
            postId++;
        }

        toPost.Id = postId;
        
        context.Posts.Add(toPost);
        context.SaveChanges();

        return Task.FromResult(toPost);
    }

    public Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto dto)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        if (!string.IsNullOrEmpty(dto.Title))
        {
            result = context.Posts.Where(post => post.Title == dto.Title);
        }

        if (!string.IsNullOrEmpty(dto.Body))
        {
            result = context.Posts.Where(post => post.body == dto.Body);
        }

        return Task.FromResult(result);
    }
}