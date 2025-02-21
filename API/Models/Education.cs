using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Education
{
  [Key]
  public int EducationId { get; set; }
  public string SchoolName { get; set; } = string.Empty;
  public string StudyCity { get; set; } = string.Empty;
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public Degree Degree { get; set; } = null!;
  public int DegreeId { get; set; }
  public int UserId { get; set; }
  public AppUser AppUser { get; set; } = null!;

}

