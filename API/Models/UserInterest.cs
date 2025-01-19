namespace API.Models;

public class UserInterest
{
  public int UserId { get; set; }
  public AppUser AppUser { get; set; } = null!;

  public int InterestId { get; set; }
  public Interest Interest { get; set; } = null!;
}
