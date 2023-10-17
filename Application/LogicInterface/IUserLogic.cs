using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterface;

public interface IUserLogic
{
    public Task<User> CreateAsync(UserCreationDTO dto);

    public Task<UserLoginDTO> ValidateLogin(UserCreationDTO dto);
}