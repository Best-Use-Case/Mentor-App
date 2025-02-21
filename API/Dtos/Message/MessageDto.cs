namespace API.Dtos.Message;

public record MessageDto
{
  public int Id { get; set; }
  public int SenderId { get; set; }
  public required string SenderUserName { get; set; }
  //public string SenderPhotoUrl { get; set; } = string.Empty;
  public int RecipientId { get; set; }
  public required string RecipientUserName { get; set; }
  //public string RecipientPhotoUrl { get; set; } = string.Empty;
  public required string Content { get; set; }
  public DateTime DateMessageSent { get; set; }
  //public bool SenderDeleted { get; set; }
  //public bool RecipientDeleted { get; set; }

}
