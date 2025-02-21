using System;
using API.Dtos.CreateUser;

namespace API.Utils;

public class MatchResponseManager
{
  public string Message { get; set; } = string.Empty;
  public bool IsSuccess { get; set; }
  public List<MatchedUsersDto> MatchedUsers { get; set; } = null!;

}
