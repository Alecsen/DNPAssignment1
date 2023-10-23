using Domain.Models;

namespace Application.DAOInterface;

public interface IPostDao
{
    Task<Post> CreateAsync(Post toPost);
}