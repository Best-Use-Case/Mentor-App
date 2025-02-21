using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Answer
{
  [Key]
  public int AnswerId { get; set; }
  public string AnswerText { get; set; } = string.Empty;
  public int QuestionId { get; set; }
  public Question Question { get; set; } = null!;
  public int UserId { get; set; }
  public AppUser AppUser { get; set; } = null!;


}
