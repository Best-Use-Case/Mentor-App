using API.Dtos.Message;
using API.Models;

namespace API.Interfaces;

public interface IMessageRepository
{
  void CreateMessage(Message message);
  Task<Message?> GetMessageAsync(int id);
  Task<List<MessageDto>> GetMessageThreadAsync(string currentUsername, string otherUsername);
  Task<bool> SaveAllAsync();

}
