using API.Dtos.CreateUser;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController(IUserRepository userRepository, ILogger<RegisterController> logger) : ControllerBase
{


  [HttpPost("register-user-details")]
  public async Task<IActionResult> RegisterUserDetials(UserDetailsDto detailsDto)
  {
    var result = await userRepository.RegisterUserDetailsAsync(detailsDto);

    if (!result.IsSuccess) return BadRequest(result);
    logger.LogInformation($"Registration attempt by {detailsDto.UserName} failed");

    return Ok(result);
  }

  [HttpPost("register-user-education")]
  public async Task<IActionResult> RegisterUserEducation(List<UserEducationDto> educationDto)
  {
    var result = await userRepository.RegisterUserEducationAsync(educationDto);
    if (!result.IsSuccess) return BadRequest(result);
    return Ok(result);
  }

  [HttpPost("register-user-interest")]
  public async Task<IActionResult> RegisterUserInterest(List<InterestUserDto> interestIds)
  {
    var result = await userRepository.RegisterUserInterestAsync(interestIds);
    if (!result.IsSuccess) return BadRequest(result);
    return Ok(result);
  }

  [HttpPost("register-user-role")]
  public async Task<IActionResult> RegisterUserRole(UserRoleDto role)
  {
    var result = await userRepository.RegisterUserRoleAsync(role);
    if (!result.IsSuccess) return BadRequest(result);
    return Ok(result);
  }

  [HttpPost("register-user-work-history")]
  public async Task<IActionResult> RegisterUserWorkHistory(List<UserWorkHistoryDto> workHistoryDto)
  {
    var result = await userRepository.RegisterUserWorkHistoryAsync(workHistoryDto);
    if (!result.IsSuccess) return BadRequest(result);
    return Ok(result);
  }

}
