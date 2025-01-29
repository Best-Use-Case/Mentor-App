namespace API.Dtos.CreateUser;

public class UserDto
{
  public required string UserName { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public required string Description { get; set; }
  public required string Gender { get; set; }
  public required int RoleId { get; set; }
  public required List<int> InterestIds { get; set; }
  public required List<EducationDto> Educations { get; set; }
  public required List<AnswerDto> Answers { get; set; }
  public required List<WorkExperienceDto> WorkExperiences { get; set; }
  public IFormFile? File { get; set; }
}
