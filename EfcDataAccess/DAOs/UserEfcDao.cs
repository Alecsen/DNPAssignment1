using Application.DAOInterface;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    public Task<AuthenticationUser> CreateAsync(AuthenticationUser user)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticationUser?> GetByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }
}