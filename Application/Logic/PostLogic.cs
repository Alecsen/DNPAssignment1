using Application.DAOInterface;
using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;
    
    
    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        AuthenticationUser? ownerUsername = await userDao.GetByUsernameAsync(dto.Username);
        if (ownerUsername == null)
            throw new Exception("You need to Login first!");
        
        Post toCreate = new Post
        {
            Owner = ownerUsername,
            body = dto.body,
            Title = dto.Title
        };

        Post Created = await postDao.CreateAsync(toCreate);

        return Created;
    }
}

