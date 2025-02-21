
using API.Models;

namespace API.Dtos.CreateUser;

public record WorkExperienceDto
{
    public int WorkExpId { get; set; }
    public required string CompanyName { get; set; }
    public required string Jobtitle { get; set; }
    public required int IndustryId { get; set; }
    public Industry Industry { get; set; } = null!;

}
