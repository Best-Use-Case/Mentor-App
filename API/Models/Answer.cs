using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Answer
{
  [Key]
  public int AnswerId { get; set; }
  public string AnswerText { get; set; } = string.Empty;
  public required Question Question { get; set; }
  public int UserId { get; set; }
  public required AppUser AppUser { get; set; }


}
