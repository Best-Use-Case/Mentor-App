using API.Data;
using API.Dtos.CreateUser;
using API.Dtos.UserProfile;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class ProfileRespository(DataContext context, IMapper mapper) : IProfileRepository
{
  public async Task<bool> UpdateProfileAsync(ProfileDto profileDto)
  {
    try
    {
      var user = await context.Users.FindAsync(profileDto.UserName);
      if (user is null) return false;
      user.FirstName = profileDto.FirstName;
      user.LastName = profileDto.LastName;
      user.Description = profileDto.Description;
      user.Gender = profileDto.Gender;

      if (await context.SaveChangesAsync() > 0) return true;

      return false;
    }
    catch (Exception)
    {
      return false;
    }

  }
  public async Task<List<EduDto>> GetEducationsForUser(int userId)
  {
    try
    {
      var userEducations = await context.Educations
                .Where(u => u.UserId == userId)
                .Include(e => e.Degree)
                .ToListAsync();
      return mapper.Map<List<EduDto>>(userEducations);
    }
    catch (Exception)
    {
      return [];
    }

  }
  public Task<bool> UpdateEducationsForUser(Education education)
  {
    throw new NotImplementedException();
  }
  public async Task<bool> DeleteEducationForUser(int eduId, int userId)
  {
    try
    {
      var edu = await context.Educations.FindAsync(eduId);
      if (edu is not null)
      {
        var userEducations = await context.Educations
              .Where(edu => edu.UserId == userId)
              .ToListAsync();
        userEducations.Remove(edu);
        return true;
      }
      if (await context.SaveChangesAsync() > 0) return true;

      return false;
    }
    catch (Exception)
    {
      return false;
    }

  }

  public Task<List<WorkExperienceDto>> GetWorkExperienceForUser(string userName)
  {
    throw new NotImplementedException();
  }
  public Task<bool> UpdateWorkExperienceForUser(WorkExperienceDto workExperienceDto)
  {
    throw new NotImplementedException();
  }
  public Task<bool> DeleteWorkExperienceForUser(int WorkId)
  {
    throw new NotImplementedException();
  }

}
