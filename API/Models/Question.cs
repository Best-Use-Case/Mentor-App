using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Question
{
  [Key]
  public int QuestionId { get; set; }
  public required string QuestionText { get; set; }
}
