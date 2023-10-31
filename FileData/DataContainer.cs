using Domain.Models;

namespace FileData;

public class DataContainer
{
    public ICollection<AuthenticationUser> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}