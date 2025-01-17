using System;

namespace API.Models;

public class Answer
{
  public int AnswerId { get; set; }
  public required Question Question { get; set; }
  public required string AnswerText { get; set; }
}
