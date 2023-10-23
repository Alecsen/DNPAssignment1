namespace Domain.DTOs;

public class UserCreationDTO
{
    public string UserName { get; set; }
    public string PassWord { get; set; }

    public UserCreationDTO(string userName, string passWord)
    {
        UserName = userName;
        PassWord = passWord;
    }
}