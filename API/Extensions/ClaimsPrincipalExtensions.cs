using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipalExtensions
{
  public static string GetUserName(this ClaimsPrincipal principal)
  {
    var username = principal.FindFirstValue(ClaimTypes.Name) ?? throw new Exception("Username cannot found");
    return username;
  }

  public static int GetUserId(this ClaimsPrincipal principal)
  {
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("UserId cannot found");
    return int.Parse(userId);
  }
}
