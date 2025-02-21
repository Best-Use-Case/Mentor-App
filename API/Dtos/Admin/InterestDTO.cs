namespace API.Dtos.Admin;

public record InterestDTO
{
  public int InterestId { get; set; }
  public string InterestName { get; set; } = string.Empty;
  public int UserId { get; set; }

}
