using Application.DAOInterface;
using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{ 
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<AuthenticationUser> CreateAsync(UserCreationDTO dto)
    {
        AuthenticationUser? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateUserName(dto);
        AuthenticationUser toCreate = new AuthenticationUser()
        {
            Username = dto.UserName,
            Age = dto.Age,
            Domain = dto.Domain,
            Email = dto.Email,
            Name = dto.Name,
            Password = dto.PassWord,
            Role = dto.Role,
            SecurityLevel = dto.SecurityLevel
        };
        
        AuthenticationUser created = await userDao.CreateAsync(toCreate);
        
        return created;
    }

    public async Task<AuthenticationUser> ValidateLogin(AuthUserLoginDto dto)
    {
        AuthenticationUser? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing == null)
            throw new Exception("User does not exist!");

        if (dto.Password != existing.Password)
        {
            throw new Exception("Wrong password");
        }
        
        return existing;

    }

    private void ValidateUserName(UserCreationDTO userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}