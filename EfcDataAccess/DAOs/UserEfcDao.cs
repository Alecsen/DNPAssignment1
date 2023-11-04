using Application.DAOInterface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{

    private readonly PostAppContext context;

    public UserEfcDao(PostAppContext context)
    {
        this.context = context;
    }

    public async Task<AuthenticationUser> CreateAsync(AuthenticationUser user)
    {
        EntityEntry<AuthenticationUser> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<AuthenticationUser?> GetByUsernameAsync(string userName)
    {
        AuthenticationUser? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Username.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }
}