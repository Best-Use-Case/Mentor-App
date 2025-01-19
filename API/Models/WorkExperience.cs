using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class WorkExperience
{
  [Key]
  public int WorkExpId { get; set; }
  public required string CompanyName { get; set; }
  public required string Jobtitle { get; set; }
  public required Industry Indudtry { get; set; }
  public int UserId { get; set; }
  public Mentor Mentor { get; set; } = null!;

}
