using API.Utils;

namespace API.Interfaces;

public interface IUserRepository
{

  Task<ResponseManager> RegisterUserDetailsAsync(UserDetailsDto detailsDto);
  Task<ResponseManager> RegisterUserRoleAsync(UserRoleDto role);
  Task<ResponseManager> RegisterUserInterestAsync(List<InterestUserDto> interests);
  Task<ResponseManager> RegisterUserEducationAsync(List<UserEducationDto> educationDtos);
  Task<ResponseManager> RegisterUserWorkHistoryAsync(List<UserWorkHistoryDto> workHistoryDto);
}

public record UserDetailsDto
{
  public required string UserName { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Gender { get; set; } = string.Empty;
}

public record UserRoleDto
{
  public required string UserName { get; set; }
  public int UserId { get; set; }
  public int RoleId { get; set; }
}

public record UserEducationDto
{
  public required string UserName { get; set; }
  public string SchoolName { get; set; } = string.Empty;
  public string StudyCity { get; set; } = string.Empty;
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public int DegreeId { get; set; }
  //public List<EducationDetailDto> EducationDetials { get; set; } = [];
}

public record EducationDetailDto
{
  public string SchoolName { get; set; } = string.Empty;
  public string StudyCity { get; set; } = string.Empty;
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public int DegreeId { get; set; }
}

public record UserWorkHistoryDto
{
  public required string UserName { get; set; }
  public string CompanyName { get; set; } = string.Empty;
  public string Jobtitle { get; set; } = string.Empty;
  public int IndustryId { get; set; }
}

public record InterestUserDto
{
  public required string UserName { get; set; }
  public List<int> InterestIds { get; set; } = [];
}

