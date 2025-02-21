namespace API.Dtos.UserProfile;

public record EduDto
{
  public int EducationId { get; set; }
  public required string SchoolName { get; set; }
  public required string StudyCity { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public required string DegreeName { get; set; }
}
