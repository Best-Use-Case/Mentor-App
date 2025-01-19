using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Education
{
  [Key]
  public int EducationId { get; set; }
  public required string SchoolName { get; set; }
  public required string StudyCity { get; set; }
  public required DateTime StartDate { get; set; }
  public required DateTime EndDate { get; set; }
  public required Degree Degree { get; set; }
  public int StudentId { get; set; }
  public Student Student { get; set; } = new Student();

}

