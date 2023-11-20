using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class AuthenticationUser
{
   
    public int Id { get; private set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    public int SecurityLevel { get; set; }
    
    public ICollection<Post> Posts { get; set; }


}