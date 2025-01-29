using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class AppUser
{
    [Key]
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty; // Email
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public string PublicId { get; set; } = string.Empty;
    public List<UserRole> Roles { get; set; } = [];
    public List<UserInterest> UserInterests { get; set; } = [];
    public List<Education>? Educations { get; set; } = [];
    public List<WorkExperience>? WorkExperiences { get; set; } = [];
    public List<Answer> Answers { get; set; } = [];

    public string FullName
    {
        get => FirstName + " " + LastName + " " + UserName;
    }


}
