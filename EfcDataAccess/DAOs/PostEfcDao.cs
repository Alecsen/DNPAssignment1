using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostAppContext context;

    public PostEfcDao(PostAppContext context)
    {
        this.context = context;
    }
    
    public async Task<Post> CreateAsync(Post toPost)
    {
        
        EntityEntry<Post> newPost = await context.Posts.AddAsync(toPost);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto dto)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Owner).AsQueryable();

        if (!string.IsNullOrEmpty(dto.UserName))
        {
            query = query.Where(Post => Post.Owner.Username.ToLower().Equals(dto.UserName.ToLower()));
        }

        if (dto.PostId != null)
        {
            query = query.Where(post => post.Id == dto.PostId);
        }

        if (!string.IsNullOrEmpty(dto.Title))
        {
            query = query.Where(post => post.Title.ToLower().Equals(dto.Title.ToLower()));
        }

        if (!string.IsNullOrEmpty(dto.Body))
        {
            query = query.Where(post => post.body.ToLower().Equals(dto.Body.ToLower()));
        }

        List<Post> result = await query.ToListAsync();

        return result;
    }
}