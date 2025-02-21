using API.Dtos.Admin;
using API.Dtos.CreateUser;
using API.Dtos.UserProfile;
using API.Models;
using API.Utils;

namespace API.Interfaces;

public interface IProfileRepository
{
  Task<ResponseManager> UpdateProfileAsync(ProfileDto profileDto);
  Task<List<EduDto>> GetEducationsForUser(int UserId);
  Task<bool> UpdateEducationsForUser(List<EducationUpdateDto> educationDto);
  Task<bool> DeleteEducationForUser(int EduId);
  Task<List<WorkHistoryDto>> GetWorkExperienceForUser(int UserId);
  Task<bool> UpdateWorkExperienceForUser(List<WorkUpdateDto> workExperienceDto);
  Task<bool> DeleteWorkExperienceForUser(int WorkId);
  Task<List<string>> GetUserInterests(int UserId);
  Task<bool> UpdateUserInterest(InterestDTO interestDTO);
  Task<bool> DeleteUserInterest(InterestDTO interestDTO);
  Task<List<string>> GetUserRoles(int userId);

}
