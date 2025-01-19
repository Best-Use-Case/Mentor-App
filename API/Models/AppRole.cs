using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class AppRole
{
  [Key]
  public int RoleId { get; set; }
  public string RoleName { get; set; } = string.Empty;
  public List<UserRole> UserRoles { get; set; } = null!;
}
