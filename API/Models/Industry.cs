using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Industry
{
  [Key]
  public int IndustryId { get; set; }
  public required string IndustryName { get; set; }
}

