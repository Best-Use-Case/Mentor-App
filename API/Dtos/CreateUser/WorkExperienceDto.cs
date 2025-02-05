
namespace API.Dtos.CreateUser;

public record WorkExperienceDto
{
    public int WorkId { get; set; }
    public required string CompanyName { get; set; }
    public required string Jobtitle { get; set; }
    public required int IndustryId { get; set; }

}
