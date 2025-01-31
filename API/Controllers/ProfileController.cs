using API.Dtos.UserProfile;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class ProfileController(IProfileRepository profile) : ControllerBase
{
  public async Task<IActionResult> UpdateProfile(ProfileDto profileDto)
  {
    if (profileDto == null) return BadRequest("Obsolete data or Not find username");
    var result = await profile.UpdateProfileAsync(profileDto);

    if (!result) return BadRequest("Updating profile failed");
    return Ok(result);


  }
}
