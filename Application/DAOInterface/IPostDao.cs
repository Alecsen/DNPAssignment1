using Domain.DTOs;
using Domain.Models;

namespace Application.DAOInterface;

public interface IPostDao
{
    Task<Post> CreateAsync(Post toPost);
    Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto dto);
}