using System;

namespace API.Dtos.Admin;

public record DegreeDTO
{
  public int DegreeId { get; set; }
  public string DegreeName { get; set; } = string.Empty;
}
