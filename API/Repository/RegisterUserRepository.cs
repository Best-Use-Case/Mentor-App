using API.Data;
using API.Interfaces;
using API.Models;
using API.Services;
using API.Utils;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class RegisterUserRepository(DataContext context, ITokenService tokenService) : IUserRepository
{
  public async Task<ResponseManager> RegisterUserDetailsAsync(UserDetailsDto detailsDto)
  {
    try
    {
      var user = await context.Users.FirstOrDefaultAsync(user =>
        user.UserName == detailsDto.UserName);
      if (user is null)
      {
        return new ResponseManager
        {
          Message = $"User with {detailsDto.UserName} email address not found",
          IsSuccess = false,
        };
      }

      user.FirstName = detailsDto.FirstName;
      user.LastName = detailsDto.LastName;
      user.Description = detailsDto.Description;
      user.Gender = detailsDto.Gender;

      if (await context.SaveChangesAsync() > 0)
      {
        return new ResponseManager
        {
          Message = "User successfully registered",
          IsSuccess = true,
          UserName = detailsDto.UserName,
          FirstName = detailsDto.FirstName,
          LastName = detailsDto.LastName,
          Token = tokenService.CreateToken(user)

        };
      }

      return new ResponseManager
      {
        Message = "Problem registering user details",
        IsSuccess = false
      };


    }
    catch (Exception ex)
    {

      return new ResponseManager { Message = $" Rgistration failed:\n{ex.Message}", IsSuccess = false };
    }

  }

  public async Task<ResponseManager> RegisterUserEducationAsync(List<UserEducationDto> educationDtos)
  {

    try
    {
      var username = "";
      foreach (var edu in educationDtos)
      {
        username = edu.UserName; ;
      }

      var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);

      if (user is null) return new ResponseManager { Message = "User not found ", IsSuccess = false };


      if (educationDtos.Count != 0)
      {
        educationDtos.ForEach(edu =>
        {
          var education = new Education()
          {
            DegreeId = edu.DegreeId,
            SchoolName = edu.SchoolName,
            StudyCity = edu.StudyCity,
            StartDate = edu.StartDate,
            EndDate = edu.EndDate,
          };
          user.Educations!.Add(education);
        });

      }

      if (await context.SaveChangesAsync() > 0)
      {
        return new ResponseManager
        {
          Message = "User successfully registered",
          IsSuccess = true,
          FirstName = user.FirstName,
          LastName = user.LastName,

        };
      }

      return new ResponseManager
      {
        Message = "Problem registering user education",
        IsSuccess = false
      };

    }
    catch (Exception ex)
    {

      return new ResponseManager { Message = $" Rgistration failed:\n{ex.Message}", IsSuccess = false };
    }

  }

  public async Task<ResponseManager> RegisterUserInterestAsync(List<InterestUserDto> interestIds)
  {

    try
    {
      var username = "";
      foreach (var ints in interestIds)
      {
        username = ints.UserName; ;
      }

      var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);
      if (user is null) return new ResponseManager { Message = "User not found", IsSuccess = false };


      if (interestIds.Count != 0)
      {
        interestIds.ForEach(interest =>
        {
          foreach (var ints in interest.InterestIds)
          {
            var userInterest = new UserInterest()
            {
              UserId = user.UserId,
              InterestId = ints
            };

            user.UserInterests.Add(userInterest);
          }


        });
      }

      await context.SaveChangesAsync();

      return new ResponseManager
      {
        Message = "User successfully registered",
        IsSuccess = true,
        FirstName = user.FirstName,
        LastName = user.LastName,
      };

    }
    catch (Exception ex)
    {

      return new ResponseManager { Message = $" Rgistration failed:\n{ex.Message}", IsSuccess = false };
    }


  }

  public async Task<ResponseManager> RegisterUserRoleAsync(UserRoleDto role)
  {
    try
    {
      if (role != null)
      {
        var userRoleDB = await context.UserRoles.Where(ur => ur.UserId == role.UserId).Select(r => r.RoleId).ToListAsync();
        var user = await context.Users.FindAsync(role.UserId);

        if (user is null) return new ResponseManager { Message = "User not found", IsSuccess = false };

        var UserRoleId = role.RoleId;

        var userRole = new UserRole()
        {
          UserId = role.UserId,
          RoleId = (int)UserRoleId
        };

        foreach (var roledb in userRoleDB)
        {
          if (roledb != UserRoleId)
          {
            var userRoleToRemove = new UserRole
            {
              UserId = role.UserId,
              RoleId = roledb
            };
            context.UserRoles.Remove(userRoleToRemove);
          }
          user.Roles.Add(userRole);

        }
        if (await context.SaveChangesAsync() > 0)
        {
          return new ResponseManager
          {
            Message = "User role registered successfully",
            IsSuccess = true,
          };
        }
      }

      return new ResponseManager
      {
        Message = "Problem registering user role",
        IsSuccess = false
      };

    }
    catch (Exception ex)
    {
      return new ResponseManager { Message = $" Rgistration failed:\n{ex.Message}", IsSuccess = false };
    }

  }

  public async Task<ResponseManager> RegisterUserWorkHistoryAsync(List<UserWorkHistoryDto> workHistoryDto)
  {
    try
    {
      var username = "";
      foreach (var edu in workHistoryDto)
      {
        username = edu.UserName; ;
      }

      var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);

      if (user is null) return new ResponseManager { Message = "User not found ", IsSuccess = false };

      if (workHistoryDto.Count != 0)
      {
        workHistoryDto.ForEach(work =>
        {
          var workHistory = new WorkExperience()
          {
            IndustryId = work.IndustryId,
            CompanyName = work.CompanyName,
            Jobtitle = work.Jobtitle,
          };
          user.WorkExperiences!.Add(workHistory);
        });
      }
      if (await context.SaveChangesAsync() > 0)
      {
        return new ResponseManager
        {
          Message = "Registeration succeeded",
          IsSuccess = true
        };
      }

      return new ResponseManager
      {
        Message = "Problem registeration work history",
        IsSuccess = false
      };
    }
    catch (Exception ex)
    {
      return new ResponseManager { Message = $" Rgistration failed:\n{ex.Message}", IsSuccess = false };
    }
  }
}
