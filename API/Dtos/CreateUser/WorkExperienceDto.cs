using System;

namespace API.Dtos.CreateUser;

public record WorkExperienceDto
{
    public required string CompanyName { get; set; }
    public required string Jobtitle { get; set; }
    public required int IndustryId { get; set; }

}
