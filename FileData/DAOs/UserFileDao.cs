using Application.DAOInterface;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<AuthenticationUser> CreateAsync(AuthenticationUser user)
    {
        /*
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;
        */
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<AuthenticationUser?> GetByUsernameAsync(string userName)
    {
        AuthenticationUser? existing = context.Users.FirstOrDefault(u =>
            u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }
}