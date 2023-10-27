using Domain.Models;

namespace WepAPI.Services;

public interface IAuthService
{
    Task<AuthenticationUser> GetUser(string username, string password);
    Task RegisterUser(AuthenticationUser user);
}