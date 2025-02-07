using API.Data;
using API.Dtos.Admin;
using API.Dtos.UserProfile;
using API.Interfaces;
using API.Utils;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class ProfileRespository(DataContext context, IMapper mapper) : IProfileRepository
{
  // swagger-tested
  public async Task<ResponseManager> UpdateProfileAsync(ProfileDto profileDto)
  {
    try
    {
      var user = await context.Users.FindAsync(profileDto.UserId);
      if (user is null) return new ResponseManager { Message = "User not found", IsSuccess = false };
      user.FirstName = profileDto.FirstName;
      user.LastName = profileDto.LastName;
      user.Description = profileDto.Description;
      user.Gender = profileDto.Gender;

      if (await context.SaveChangesAsync() > 0)
      {
        return new ResponseManager
        {
          FirstName = profileDto.FirstName,
          LastName = profileDto.LastName,
          Description = profileDto.Description,
          Gender = profileDto.Gender,
          Message = "Updated successfully",
          IsSuccess = true
        };
      }
      return new ResponseManager { Message = "Updating failed", IsSuccess = false };
    }
    catch (Exception ex)
    {
      return new ResponseManager { IsSuccess = false, Message = "Updating failed\n" + ex.Message };
    }

  }

  // swagger-test
  public async Task<List<EduDto>> GetEducationsForUser(int UserId)
  {
    try
    {
      var userEducations = await context.Educations
                .Where(u => u.UserId == UserId)
                .Include(e => e.Degree)
                .ToListAsync();
      return mapper.Map<List<EduDto>>(userEducations);
    }
    catch (Exception)
    {
      return [];
    }

  }
  // Swagger-tested
  public async Task<bool> UpdateEducationsForUser(List<EducationUpdateDto> educationDto)
  {
    try
    {
      educationDto.ForEach(edu =>
      {
        var userEducation = context.Educations.Find(edu.EducationId);
        if (userEducation != null)
        {
          mapper.Map(edu, userEducation);
        }
      });
      if (await context.SaveChangesAsync() > 0) return true;

      return false;

    }
    catch (Exception)
    {

      return false;
    }

  }
  //swagger-tested
  public async Task<bool> DeleteEducationForUser(int EduId)
  {
    try
    {
      var edu = await context.Educations.FindAsync(EduId);
      if (edu is not null)
      {
        context.Educations.Remove(edu);
      }
      if (await context.SaveChangesAsync() > 0) return true;

      return false;
    }
    catch (Exception)
    {
      return false;
    }

  }

  // swagger-test
  public async Task<List<WorkHistoryDto>> GetWorkExperienceForUser(int UserId)
  {
    try
    {
      var userWorkHistories = await context.WorkExperiences
                    .Where(w => w.UserId == UserId)
                    .Include(x => x.Indudtry)
                    .ToListAsync();
      return mapper.Map<List<WorkHistoryDto>>(userWorkHistories);
    }
    catch (Exception)
    {
      return [];
    }
  }
  // swagger-testd
  public async Task<bool> UpdateWorkExperienceForUser(List<WorkUpdateDto> workExperienceDto)
  {
    try
    {
      workExperienceDto.ForEach(work =>
      {
        var userWorkHistoryDb = context.WorkExperiences.Find(work.WorkExpId);
        if (userWorkHistoryDb != null)
        {
          mapper.Map(work, userWorkHistoryDb);
        }
      });
      return await context.SaveChangesAsync() > 0;

    }
    catch (Exception)
    {
      return false;
    }
  }
  // swagger-tested
  public async Task<bool> DeleteWorkExperienceForUser(int WorkId)
  {
    try
    {
      var workToDeleted = await context.WorkExperiences.FindAsync(WorkId);
      if (workToDeleted != null)
      {
        var result = context.WorkExperiences.Remove(workToDeleted);
      }
      if (await context.SaveChangesAsync() > 0) return true;
      return false;
    }
    catch (Exception)
    {
      return false;
    }
  }

  // swagger-tested
  public async Task<List<string>> GetUserInterests(int UserId)
  {
    try
    {
      var userInterestList = new List<string>();
      var userinterestIds = await context.UserInterests.Where(ints => ints.UserId == UserId)
                                                        .Select(s => s.InterestId)
                                                        .ToListAsync();
      if (userinterestIds.Count > 0)
      {
        userinterestIds.ForEach(ints =>
        {
          userInterestList = [.. context.Interests.Where(x => x.InterestId == ints).Select(x => x.InterestName)];// vs-code recommendation
          // userInterestList = context.Interests.Where(x => x.InterestId == ints)
          //                                       .Select(x => x.InterestName)
          //                                       .ToList();
        });
        return userInterestList;
      }

      return ["No interest found for the user"];
    }
    catch (Exception ex)
    {

      return ["Something went wrong\n" + ex.Message];
    }
  }

  public async Task<bool> UpdateUserInterest(InterestDTO interestDTO) // TODO: This will be removed 
  {
    try
    {
      var userInterestToUpdated = await context.UserInterests.FirstOrDefaultAsync(x => x.InterestId == interestDTO.InterestId
                      && x.UserId == interestDTO.UserId);
      if (userInterestToUpdated != null)
      {
        var interestToUpdated = await context.Interests.FirstOrDefaultAsync(x => x.InterestId == userInterestToUpdated.InterestId);
        if (interestToUpdated != null)
        {
          interestToUpdated.InterestName = interestDTO.InterestName;
        }
      }
      return await context.SaveChangesAsync() > 0;
    }
    catch (Exception)
    {

      return false;
    }
  }

  // swagger-tested
  public async Task<bool> DeleteUserInterest(InterestDTO interestDTO)
  {
    try
    {
      var ints = await context.UserInterests.FirstOrDefaultAsync(x => x.UserId == interestDTO.UserId && x.InterestId == x.InterestId);
      if (ints != null)
      {
        var result = context.UserInterests.Remove(ints);

      }
      if (await context.SaveChangesAsync() > 0) return true;
      return false;
    }
    catch (Exception)
    {
      return false;
    }

  }

  public async Task<List<string>> GetUserRoles(int userId)
  {
    try
    {
      var userRoles = await context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToListAsync();
      var roles = new List<string>();
      if (userRoles.Count > 0)
      {
        userRoles.ForEach(roleId =>
        {
          roles = context.AppRoles.Where(r => r.RoleId == roleId).Select(r => r.RoleName).ToList();
        });
      }
      return roles;
    }
    catch (Exception)
    {
      return [""];
    }
  }
}
