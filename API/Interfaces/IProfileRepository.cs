using API.Dtos.CreateUser;
using API.Dtos.UserProfile;

namespace API.Interfaces;

public interface IProfileRepository
{
  // update firstname, lastname, description, gender -> dto
  Task<bool> UpdateProfileAsync(ProfileDto profileDto);


  //Get all Edu for current-user, update and delete func
  Task<List<EduDto>> GetEducationsForUser(int UserId);
  Task<bool> UpdateEducationsForUser(List<EducationUpdateDto> educationDto);
  Task<bool> DeleteEducationForUser(int EduId);


  //Get all Work-history for current-user and add, update and delete
  Task<List<WorkHistoryDto>> GetWorkExperienceForUser(int UserId);
  Task<bool> UpdateWorkExperienceForUser(List<WorkExperienceDto> workExperienceDto);
  // Get all interests for current-user and add and delete -> iff user has still one interest registered
  Task<bool> DeleteWorkExperienceForUser(int WorkId);
  //

}
