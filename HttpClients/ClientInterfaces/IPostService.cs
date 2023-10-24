using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> Create(PostCreationDTO dto);
    Task<ICollection<Post>> GetAsync(string? userName, int? userId, string? titleContains, string? bodyContains);
}