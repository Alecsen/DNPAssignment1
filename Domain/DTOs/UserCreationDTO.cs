namespace Domain.DTOs;

public class UserCreationDTO
{
    public string UserName { get; }
    public string PassWord { get; }

    public UserCreationDTO(string userName, string passWord)
    {
        UserName = userName;
        PassWord = passWord;
    }
}