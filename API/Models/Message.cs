using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Message
{
  [Key]
  public int Id { get; set; }
  public required string SenderUserName { get; set; }
  public required string RecipientUserName { get; set; }
  public required string Content { get; set; }
  public DateTime DateMessageSent { get; set; } = DateTime.UtcNow;
  public int SenderId { get; set; }
  public AppUser Sender { get; set; } = null!;
  public int RecipientId { get; set; }
  public AppUser Recipient { get; set; } = null!;
}
