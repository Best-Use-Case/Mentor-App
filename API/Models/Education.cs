using System;

namespace API.Models;

public class Education
{
  public int EducationId { get; set; }
  public required string SchoolName { get; set; }
  public required string StudyCity { get; set; }
  public required DateTime StartDate { get; set; }
  public required DateTime EndDate { get; set; }
  public required Degree Degree { get; set; }

}

