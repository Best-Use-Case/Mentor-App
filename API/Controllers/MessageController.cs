using API.Dtos.Message;
using API.Extensions;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MessageController(
  IMessageRepository messageRepository,
  IUserRepo userRepo,
  IMapper mapper
  ) : ControllerBase
{
  [HttpPost("send-message")]
  public async Task<ActionResult> SendMessage(SendMessageDto sendMessageDto)
  {
    var sender = await userRepo.GetUserByUsername(sendMessageDto.SenderUsername);
    var recipient = await userRepo.GetUserByUsername(sendMessageDto.RecipientUsername);
    if (sender == null || recipient == null) return BadRequest("Message could not be sent");
    var content = sendMessageDto.Content;
    if (content == null) return BadRequest("Message needs to have content");

    var message = new Message
    {
      Sender = sender,
      Recipient = recipient,
      SenderUserName = sender.UserName,
      RecipientUserName = recipient.UserName,
      Content = content
    };

    messageRepository.CreateMessage(message);
    if (await messageRepository.SaveAllAsync())
      return Ok(mapper.Map<MessageDto>(message));

    return BadRequest("Could not able to send your message");
  }

  [HttpGet("get-user-message/{id}")]
  public async Task<ActionResult<Message>> GetMessageForUser(int id)
  {
    var messageDb = await messageRepository.GetMessageAsync(id);

    if (messageDb == null) return NotFound("message not found");
    return Ok(messageDb);
  }

  [HttpGet("get-message-thread/{otherUserName}")]
  public async Task<ActionResult<MessageDto>> GetMessageThread(string otherUserName)
  {
    //var currentUsername = User.GetUserName();
    string currentUsername = "zerfine@gmail.com";
    var messageThread = await messageRepository.GetMessageThreadAsync(currentUsername, otherUserName);
    return Ok(messageThread);
  }

}
