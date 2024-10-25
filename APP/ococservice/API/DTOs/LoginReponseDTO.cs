namespace API.DTOs;

public class LoginReponseDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }

    public string Token { get; set; }
}
