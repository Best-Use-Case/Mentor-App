namespace API.Dtos.CreateUser;

public class UserDto
{
  public required string UserName { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public string Description { get; set; } = string.Empty;
  public string Gender { get; set; } = string.Empty;
  public int? RoleId { get; set; }
  public List<int> InterestIds { get; set; } = [];
  public List<EducationDto> Educations { get; set; } = [];
  public List<AnswerDto> Answers { get; set; } = [];
  public List<WorkExperienceDto> WorkExperiences { get; set; } = [];
  //public IFormFile? File { get; set; }
}
