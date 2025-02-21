namespace API.Dtos.CreateUser;

public record EducationDto
{
    public required string SchoolName { get; set; }
    public required string StudyCity { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required int DegreeId { get; set; }

}
