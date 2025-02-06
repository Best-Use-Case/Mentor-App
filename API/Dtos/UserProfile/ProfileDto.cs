namespace API.Dtos.UserProfile;

public record ProfileDto
{
  public required int UserId { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Gender { get; set; } = string.Empty;

}
