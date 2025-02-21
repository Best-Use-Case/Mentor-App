using System;
using API.Models;
using API.Utils;

namespace API.Dtos.CreateUser;

public class MatchedUsersDto
{
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public List<string> Interests { get; set; } = [];

}

