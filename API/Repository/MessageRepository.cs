using API.Data;
using API.Dtos.Message;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class MessageRepository(DataContext context, IMapper mapper) : IMessageRepository
{
  public async void CreateMessage(Message message)
  {
    await context.Messages.AddAsync(message);
  }

  public async Task<Message?> GetMessageAsync(int id)
  {
    return await context.Messages.FindAsync(id);

  }
  public async Task<List<MessageDto>> GetMessageThreadAsync(string currentUsername, string otherUsername)
  {
    var messages = await context.Messages.Where(m => m.RecipientUserName == currentUsername && m.SenderUserName == otherUsername
      || m.SenderUserName == currentUsername && m.RecipientUserName == otherUsername
      ).OrderBy(m => m.DateMessageSent).ToListAsync();

    return mapper.Map<List<MessageDto>>(messages);
  }

  public async Task<bool> SaveAllAsync()
  {
    return await context.SaveChangesAsync() > 0;
  }
}
