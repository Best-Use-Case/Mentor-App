using API.Models;

namespace API.Dtos.UserProfile;

public record WorkHistoryDto
{
  public int WorkExpId { get; set; }
  public string CompanyName { get; set; } = string.Empty;
  public string Jobtitle { get; set; } = string.Empty;
  public string IndustryName { get; set; } = null!;

}

public record WorkUpdateDto
{
  public int WorkExpId { get; set; }
  public string CompanyName { get; set; } = string.Empty;
  public string Jobtitle { get; set; } = string.Empty;
  public int IndustryId { get; set; }
}
