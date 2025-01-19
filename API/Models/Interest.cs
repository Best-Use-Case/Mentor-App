using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Interest
{
  [Key]
  public int InterestId { get; set; }
  public required string InterestName { get; set; }
  public int FieldOfInterestId { get; set; }
  public FieldOfInterest FieldOfInterest { get; set; } = null!;
  public List<UserInterest> UserInterests { get; set; } = [];


}
