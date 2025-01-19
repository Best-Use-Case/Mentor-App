using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Degree
{
  [Key]
  public int DegreeId { get; set; }
  public required string DegreeName { get; set; }
}
