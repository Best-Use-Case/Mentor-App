namespace API.Dtos.UserProfile;

public record EducationUpdateDto
{

  public int EducationId { get; set; }
  public required string SchoolName { get; set; }
  public required string StudyCity { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public int DegreeId { get; set; }
  public int UserId { get; set; }


}
