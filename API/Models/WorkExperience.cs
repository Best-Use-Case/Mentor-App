using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class WorkExperience
{
  [Key]
  public int WorkExpId { get; set; }
  public string CompanyName { get; set; } = string.Empty;
  public string Jobtitle { get; set; } = string.Empty;
  public int IndustryId { get; set; }
  public Industry Indudtry { get; set; } = null!;
  public int UserId { get; set; }
  public AppUser AppUser { get; set; } = null!;

}
