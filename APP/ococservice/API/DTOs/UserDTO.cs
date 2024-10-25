namespace API.DTOs;


public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Role { get; set; }
    public string Gender { get; set; }
    public string Job { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }

    // public string Token { get; set; }
}
