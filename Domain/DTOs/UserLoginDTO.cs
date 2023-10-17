namespace Domain.DTOs;

public class UserLoginDTO
{
    public string userName { get; set; }
    public bool login { get; set; }

    public UserLoginDTO(string userName, bool login)
    {
        this.userName = userName;
        this.login = login;
    }
}