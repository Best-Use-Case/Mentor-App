namespace API.Dtos.Message;

public record SendMessageDto
{
  public required string RecipientUsername { get; set; }
  public required string SenderUsername { get; set; }
  public required string Content { get; set; }
}
