using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class FieldOfInterest
{
  [Key]
  public int Id { get; set; }
  public string Category { get; set; } = string.Empty;
  public List<Interest> Interests { get; set; } = [];

  //public Dictionary<string, List<Interest>> FieldsOfInterest { get; set; } = [];
}
