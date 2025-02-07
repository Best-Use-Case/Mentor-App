using API.Dtos.Message;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MessageController(
  IMessageRepository messageRepository,
  IUserRepo userRepo
  ) : ControllerBase
{
  [HttpPost]
  public async Task<ActionResult> SendMessage(SendMessageDto sendMessageDto)
  {
    var sender = await userRepo.GetUserByUsername(sendMessageDto.SenderUsername);
    var recipient = await userRepo.GetUserByUsername(sendMessageDto.RecipientUsername);
    if (sender == null || recipient == null) return BadRequest("Message could not be sent");
    var content = sendMessageDto.Content;
    if (content == null) return BadRequest("Message needs to have content");

    var message = new Message
    {
      SenderUserName = sender.UserName,
      RecipientUserName = recipient.UserName,
      Content = content
    };

    messageRepository.CreateMessage(message);

    return Ok();
  }

  [HttpGet("id")]
  public async Task<ActionResult<Message>> GetMessageForUser(int id)
  {
    var messageDb = await messageRepository.GetMessageAsync(id);

    if (messageDb == null) return NotFound("message not found");
    return Ok(messageDb);
  }

  [HttpGet("message-thread")]
  public async Task<ActionResult<MessageDto>> GetMessageThread(string currentUsername, string otherUsername)
  {
    var messageThread = await messageRepository.GetMessageThreadAsync(currentUsername, otherUsername);
    return Ok(messageThread);
  }

}
