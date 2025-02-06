namespace API.Dtos.Admin;

public record AddInterestDto
{
  public required string InterestName { get; set; }
  public int FieldOfInterestId { get; set; }

}
