namespace API.Models;

public class FieldOfInterest
{
  public int Id { get; set; }
  public string Category { get; set; } = string.Empty;
  public List<Interest> Interests { get; set; } = [];

  //public Dictionary<string, List<Interest>> FieldsOfInterest { get; set; } = [];
}
