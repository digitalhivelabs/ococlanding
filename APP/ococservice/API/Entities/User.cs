using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string UserName { get; set;}

    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    [MaxLength(250)]
    public string Email { get; set; }
    [MaxLength(15)]
    public string Status { get; set; } // Pending , Approved, Reject
    [MaxLength(20)]
    public string Country { get; set; }
    [MaxLength(25)]
    public string Role { get; set; }
    [MaxLength(25)]
    public string Job { get; set; }
    [MaxLength(15)]
    public string Gender { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }

    // RelationShip
    public List<Documento> Documents { get; set; }
    public List<Documento> DocumentUpdates { get; set; }
    public List<Spesimen> Spesimens { get; set; }

}
