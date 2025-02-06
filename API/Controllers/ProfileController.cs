using API.Dtos.Admin;
using API.Dtos.CreateUser;
using API.Dtos.UserProfile;
using API.Interfaces;
using API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class ProfileController(IProfileRepository profile) : ControllerBase
{
  [HttpPost("update-user")]
  public async Task<ActionResult<ResponseManager>> UpdateProfile(ProfileDto profileDto)
  {
    if (profileDto.UserId == 0) return BadRequest("No user found");
    var result = await profile.UpdateProfileAsync(profileDto);

    if (!result.IsSuccess) return BadRequest("Problem updating profile");
    return Ok(result);
  }

  [HttpGet("get-education/{UserId}")]
  public async Task<ActionResult<List<EduDto>>> GetEducationForUser(int UserId)
  {
    var educations = await profile.GetEducationsForUser(UserId);
    if (educations == null) return BadRequest("Could not find any educations");
    return Ok(educations);
  }

  [HttpPut("update-education")]
  public async Task<ActionResult> UpdateEducationForUser(List<EducationUpdateDto> updateDtos)
  {
    if (updateDtos.Count == 0) return BadRequest("No data given for update");
    var result = await profile.UpdateEducationsForUser(updateDtos);
    if (!result) return BadRequest("Problem updating education");
    return Ok("Updated successfully\n" + result);
  }

  [HttpDelete("delete-education/{EduId}")]
  public async Task<IActionResult> DeleteEducationForUser(int EduId)
  {
    var result = await profile.DeleteEducationForUser(EduId);
    if (!result) return BadRequest("Problem deleting the item");
    return Ok("Deleted successfully\n" + result);
  }

  [HttpGet("get-work-history/{UserId}")]
  public async Task<ActionResult<List<WorkExperienceDto>>> GetWorkHistoryForUser(int UserId)
  {
    var result = await profile.GetWorkExperienceForUser(UserId);
    if (result.Count == 0) return BadRequest("No work history found for the user");
    return Ok(result);
  }

  [HttpPost("update-work-history")]
  public async Task<ActionResult> UpdateWorkHistory(List<WorkUpdateDto> workExperienceDtos)
  {
    if (workExperienceDtos.Count == 0) return NotFound("No work history to be updated");
    var result = await profile.UpdateWorkExperienceForUser(workExperienceDtos);
    if (!result) return BadRequest("Problem updating work-histoty");
    return Ok("Updated successfully\n" + result);
  }

  [HttpDelete("delete-work/{WorkId}")]
  public async Task<ActionResult> DeleteWorkExperience(int WorkId)
  {
    var result = await profile.DeleteWorkExperienceForUser(WorkId);
    if (!result) return BadRequest("Problem deleting work-history");
    return Ok(result);
  }

  [HttpGet("get-user-interests/{UserId}")]
  public async Task<ActionResult<List<string>>> GetUserInterests(int UserId)
  {
    var result = await profile.GetUserInterests(UserId);
    if (result.Count == 0) return NotFound("No interest for the user found");
    return Ok(result);
  }

  [HttpPut("update-interest")]
  public async Task<ActionResult> UpdateInterest(InterestDTO interestDTO)
  {
    var result = await profile.UpdateUserInterest(interestDTO);
    if (!result) return BadRequest("Problem updating interest");
    return Ok(result);
  }

  [HttpDelete("delete-user-interest")]
  public async Task<ActionResult> DeleteInterest(InterestDTO interestDTO)
  {
    var result = await profile.DeleteUserInterest(interestDTO);
    if (!result) return BadRequest("Problem deleting user interest");
    return Ok("Successfully deleted");
  }

  [HttpGet("get-user-roles/{userId}")]
  public async Task<ActionResult<List<string>>> GetUserRoles(int userId)
  {
    var result = await profile.GetUserRoles(userId);
    if (result.Count == 0) return NotFound("No role found for the user");
    return Ok(result);
  }

}
