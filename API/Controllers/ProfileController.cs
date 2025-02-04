using API.Dtos.CreateUser;
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
    if (profileDto == null) return BadRequest("No data given for update");
    var result = await profile.UpdateProfileAsync(profileDto);

    if (!result) return BadRequest("Problem updating profile");
    return Ok(result);
  }

  [HttpGet("get-education/{UserId}")]
  public async Task<ActionResult<List<EduDto>>> GetEducationForUser(int UserId)
  {
    if (UserId == 0) return BadRequest();
    return await profile.GetEducationsForUser(UserId);
  }

  [HttpPut("update-education")]
  public async Task<ActionResult> UpdateEducationForUser(List<EducationUpdateDto> updateDtos)
  {
    if (updateDtos.Count == 0) return BadRequest("No data given for update");
    var result = await profile.UpdateEducationsForUser(updateDtos);
    if (!result) return BadRequest("Problem updating education");
    return Ok(result);
  }

  [HttpDelete("delete-education/{EduId}")]
  public async Task<IActionResult> DeleteEducationForUser(int EduId)
  {
    if (EduId == 0) return BadRequest();
    var result = await profile.DeleteEducationForUser(EduId);
    if (!result) return BadRequest("Problem deleting the item");
    return Ok(result);
  }

  [HttpGet("get-work-history/{UserId}")]
  public async Task<ActionResult<List<WorkExperienceDto>>> GetWorkHistoryForUser(int UserId)
  {
    if (UserId == 0) return BadRequest();
    var result = await profile.GetWorkExperienceForUser(UserId);
    if (result.Count == 0) return BadRequest("No work history found for the user");
    return Ok(result);
  }

  [HttpPut("update-work-history")]
  public async Task<ActionResult> UpdateWorkHistory(List<WorkExperienceDto> workExperienceDtos)
  {
    if (workExperienceDtos.Count == 0) return NotFound("No work history to be updated");
    var result = await profile.UpdateWorkExperienceForUser(workExperienceDtos);
    if (!result) return BadRequest("Problem updating work-histoty");
    return Ok(result);
  }

  [HttpDelete("delete-work/{WorkId}")]
  public async Task<ActionResult> DeleteWorkExperience(int WorkId)
  {
    if (WorkId == 0) return BadRequest("No work history found to delete");
    var result = await profile.DeleteWorkExperienceForUser(WorkId);
    if (!result) return BadRequest("Problem deleting work-history");
    return Ok(result);
  }

}
