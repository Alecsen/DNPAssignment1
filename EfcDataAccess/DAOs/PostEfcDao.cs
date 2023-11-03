using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    public Task<Post> CreateAsync(Post toPost)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto dto)
    {
        throw new NotImplementedException();
    }
}