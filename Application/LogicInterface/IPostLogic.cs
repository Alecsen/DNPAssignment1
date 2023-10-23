using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterface;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDTO dto);
}