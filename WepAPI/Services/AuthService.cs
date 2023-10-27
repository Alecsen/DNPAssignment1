using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace WepAPI.Services;

public class AuthService : IAuthService
{
    
    private readonly IList<AuthenticationUser> users = new List<AuthenticationUser>
    {
        new AuthenticationUser
        {
            Age = 24,
            Email = "304316@via.dk",
            Domain = "via",
            Name = "Alexander Kubel",
            Password = "1234",
            Role = "Teacher",
            Username = "axeku",
            SecurityLevel = 4
        },
        new AuthenticationUser
        {
            Age = 26,
            Email = "Rolf@gmail.com",
            Domain = "gmail",
            Name = "Rolf Kyed",
            Password = "passord",
            Role = "Student",
            Username = "Krollo",
            SecurityLevel = 2
        }
    };

    
    
    public Task<AuthenticationUser> GetUser(string username, string password)
    {
        AuthenticationUser? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(AuthenticationUser user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }
}