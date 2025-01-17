using System;

namespace API.Models;

public class WorkExperience
{
  public int WorkExpId { get; set; }
  public required string CompanyName { get; set; }
  public required string Jobtitle { get; set; }
  public required Industry Indudtry { get; set; }

}
