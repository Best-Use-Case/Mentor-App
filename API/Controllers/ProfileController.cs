using API.Dtos.UserProfile;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class ProfileController(IProfileRepository profile) : ControllerBase
{
  [HttpPut("update-user")]
  public async Task<IActionResult> UpdateProfile(ProfileDto profileDto)
  {
    if (profileDto == null) return BadRequest();
    var result = await profile.UpdateProfileAsync(profileDto);

    if (!result) return BadRequest("Updating profile failed");
    return Ok(result);
  }

  [HttpGet("get-education/{userId}")]
  public async Task<ActionResult<List<EduDto>>> GetEducationForUser(int userId)
  {
    if (userId == 0) return BadRequest();
    return await profile.GetEducationsForUser(userId);
  }

  // TODO: the route parameters need to be modified
  [HttpDelete("delete-education/{eduId, userId}")]
  public async Task<IActionResult> DeleteEducationForUser(int eduId, int userId)
  {
    if (eduId == 0 || userId == 0) return BadRequest();
    var result = await profile.DeleteEducationForUser(eduId, userId);
    if (!result) return BadRequest();
    return Ok(result);
  }

}
