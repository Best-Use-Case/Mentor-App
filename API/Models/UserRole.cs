using System;

namespace API.Models;

public class UserRole
{
  public int UserId { get; set; }
  public AppUser? AppUser { get; set; } = null;
  public int RoleId { get; set; }
  public AppRole? AppRole { get; set; } = null;
}
