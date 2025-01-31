
using API.Dtos.CreateUser;
using API.Dtos.UserProfile;
using API.Models;

namespace API.Interfaces;

public interface IProfileRepository
{

  // update firstname, lastname, description, gender -> dto
  Task<bool> UpdateProfileAsync(ProfileDto profileDto);
  //Get all Edu for current-user, update and delete func


  Task<List<EduDto>> GetEducationsForUser(int userId);
  Task<bool> UpdateEducationsForUser(Education education);
  Task<bool> DeleteEducationForUser(int EduId);
  //Get all Work-history for current-user and add, update and delete


  Task<List<WorkExperienceDto>> GetWorkExperienceForUser(string userName);
  // Get all interests for current-user and add and delete -> iff user has still one interest registered
  Task<bool> UpdateWorkExperienceForUser(WorkExperienceDto workExperienceDto);
  Task<bool> DeleteWorkExperienceForUser(int WorkId);
  //

}
