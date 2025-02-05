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
      var user = await context.Users.FindAsync(profileDto.UserId);
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
  public async Task<bool> UpdateEducationsForUser(List<EducationUpdateDto> educationDto)
  {
    try
    {
      educationDto.ForEach(async edu =>
      {
        var userEducation = await context.Educations.FindAsync(edu.EducationId);
        if (userEducation != null)
        {
          // userEducation.EducationId = edu.EducationId;
          // userEducation.SchoolName = edu.SchoolName;
          // userEducation.StudyCity = edu.StudyCity;
          // userEducation.StartDate = edu.StartDate;
          // userEducation.EndDate = edu.EndDate;
          // userEducation.DegreeId = edu.DegreeId;
          // userEducation.UserId = edu.UserId;

          mapper.Map<List<Education>>(edu);
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
  public async Task<bool> DeleteEducationForUser(int EduId)
  {
    try
    {
      var edu = await context.Educations.FindAsync(EduId);
      if (edu is not null)
      {
        context.Educations.Remove(edu); // check if the DegreeId is removed ass well
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
  public async Task<bool> UpdateWorkExperienceForUser(List<WorkExperienceDto> workExperienceDto)
  {
    try
    {
      workExperienceDto.ForEach(async work =>
      {
        var userWorkHistory = await context.WorkExperiences.FindAsync(work.WorkId);
        if (userWorkHistory != null)
        {
          mapper.Map<WorkExperience>(work);
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
  public async Task<bool> DeleteWorkExperienceForUser(int WorkId)
  {
    try
    {
      var workToDeleted = await context.WorkExperiences.FindAsync(WorkId);
      if (workToDeleted != null)
      {
        var result = context.WorkExperiences.Remove(workToDeleted);
        return true;
      }
      return false;
    }
    catch (Exception)
    {

      return false;
    }
  }

}
