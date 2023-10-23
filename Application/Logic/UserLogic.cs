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

    public async Task<User> CreateAsync(UserCreationDTO dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateUserName(dto);
        User toCreate = new User
        {
            userName = dto.UserName,
            password = dto.PassWord
        };
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }

    public async Task<UserLoginDTO> ValidateLogin(UserCreationDTO dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing == null)
            throw new Exception("User does not exist!");

        if (dto.PassWord != existing.password)
        {
            throw new Exception("Wrong password");
        }

        UserLoginDTO userDto = new UserLoginDTO(dto.UserName, true);
        
        return userDto;

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