using System;

namespace API.Models;

public class Question
{
  public int QuestionId { get; set; }
  public required string QuestionText { get; set; }
}
