using API.Dtos.CreateUser;
using API.Models;
using API.Utils;

namespace API.Interfaces;

public interface IUserRepo
{
  Task<ResponseManager> CreateUser(UserDto userDto);
  Task<MatchResponseManager> MatchUsers(string UserName);
  Task<AppUser> GetUserByUsername(string userName);
  Task<AppUser> GetUserById(int id);
}
