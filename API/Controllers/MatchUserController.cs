using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class MatchUserController(IUserRepo userRepo, ILogger<RegisterController> logger) : ControllerBase
{

  [HttpGet("match-users")]
  public async Task<IActionResult> MatchUsers(string UserName)
  {
    var result = await userRepo.MatchUsers(UserName);

    if (!result.IsSuccess) return BadRequest(result);
    logger.LogInformation($"Match making attempt for {UserName} failed");

    return Ok(result);
  }


}
