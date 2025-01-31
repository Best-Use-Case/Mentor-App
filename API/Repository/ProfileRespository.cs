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
      var usersWithEducation = await context.Users.Include(u => u.Educations).ToListAsync();
      var eduToReturn = new List<EduDto>();
      if (usersWithEducation is not null)
      {
        usersWithEducation.ForEach(userEdu =>
        {
          if (userEdu.Educations!.Count > 0)
          {
            var edu = userEdu.Educations.Where(u => u.UserId == userId).ToList();
          }
          eduToReturn = mapper.Map<List<EduDto>>(userEdu);
        });
      }
      return eduToReturn;
    }
    catch (Exception)
    {
      return [];
    }

  }
  public Task<bool> DeleteEducationForUser(int EduId)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteWorkExperienceForUser(int WorkId)
  {
    throw new NotImplementedException();
  }


  public Task<List<WorkExperienceDto>> GetWorkExperienceForUser(string userName)
  {
    throw new NotImplementedException();
  }

  public Task<bool> UpdateEducationsForUser(Education education)
  {
    throw new NotImplementedException();
  }



  public Task<bool> UpdateWorkExperienceForUser(WorkExperienceDto workExperienceDto)
  {
    throw new NotImplementedException();
  }
}
