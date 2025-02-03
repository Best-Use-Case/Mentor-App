using API.Dtos.CreateUser;
using API.Utils;

namespace API.Interfaces;

public interface IUserRepo
{
  Task<ResponseManager> CreateUser(UserDto userDto);
  Task<MatchResponseManager> MatchUsers(string UserName);
}
