using System;

namespace API.Dtos.CreateUser;

public record AnswerDto
{
    public required string AnswerText { get; set; }
    public required int QuestionId { get; set; }

}
