using API.Dtos.CreateUser;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController(IUserRepo userRepo, ILogger<RegisterController> logger) : ControllerBase
{
  private readonly IUserRepo _userRepo = userRepo;
  private readonly ILogger<RegisterController> _logger = logger;

  [HttpPost("register-user")]
  public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
  {
    var result = await _userRepo.CreateUser(userDto);

    if (!result.IsSuccess) return BadRequest(result);
    _logger.LogInformation($"Registration attempt by {userDto.UserName} failed");

    return Ok(result);

  }

  [HttpGet("match-users")]
  public async Task<IActionResult> MatchUsers(string UserName)
  {
    var result = await _userRepo.MatchUsers(UserName);

    if (!result.IsSuccess) return BadRequest(result);
    _logger.LogInformation($"Match making attempt for {UserName} failed");

    return Ok(result);
  }

}
