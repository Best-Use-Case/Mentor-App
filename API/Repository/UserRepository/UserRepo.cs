using API.Data;
using API.Dtos.CreateUser;
using API.Interfaces;
using API.Models;
using API.Services;
using API.Utils;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.UserRepository;

public class UserRepo : IUserRepo
{
  private readonly DataContext _context;
  private readonly ITokenService _tokenService;
  //private readonly ImageSerivice _imageSerivice;
  //ImageSerivice imageSerivice

  public UserRepo(DataContext context, ITokenService tokenService)
  {
    //_imageSerivice = imageSerivice;
    _context = context;
    _tokenService = tokenService;
  }

  public async Task<ResponseManager> CreateUser(UserDto userDto)
  {
    try
    {
      var user = await _context.Users.FirstOrDefaultAsync(user =>
          user.UserName == userDto.UserName);
      if (user is null)
      {
        return new ResponseManager
        {
          Message = $"User with {userDto.UserName} email address not found",
          IsSuccess = false,
        };
      }
      var userIdDB = user.UserId;
      var userRoleDB = await _context.UserRoles.Where(ur => ur.UserId == userIdDB).Select(r => r.RoleId).ToListAsync();

      user.FirstName = userDto.FirstName;
      user.LastName = userDto.LastName;
      user.Description = userDto.Description;
      user.Gender = userDto.Gender;

      if (userDto.Educations.Count != 0)
      {
        userDto.Educations.ForEach(edu =>
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


          //await _context.Educations.AddAsync(education);
        });

      }

      if (userDto.WorkExperiences.Count != 0)
      {
        userDto.WorkExperiences.ForEach(work =>
        {
          var workHistory = new WorkExperience()
          {
            IndustryId = work.IndustryId,
            CompanyName = work.CompanyName,
            Jobtitle = work.Jobtitle,
          };
          user.WorkExperiences!.Add(workHistory);
          //await _context.WorkExperiences.AddAsync(workHistory);
        });

      }

      if (userDto.Answers.Count != 0)
      {
        userDto.Answers.ForEach(ans =>
        {
          var answers = new Answer()
          {
            AnswerText = ans.AnswerText,
            QuestionId = ans.QuestionId,
          };
          user.Answers.Add(answers);
        });
      }

      if (userDto.RoleId != null)
      {
        var UserRoleId = userDto.RoleId;

        var userRole = new UserRole()
        {
          UserId = user.UserId,
          RoleId = (int)UserRoleId
        };

        foreach (var role in userRoleDB)
        {
          if (role != UserRoleId)
          {
            var userRoleToRemove = new UserRole
            {
              UserId = user.UserId,
              RoleId = role
            };
            _context.UserRoles.Remove(userRoleToRemove);
          }
        }
        user.Roles.Add(userRole);


        //await _context.UserRoles.AddAsync(userRole);

      }

      if (userDto.InterestIds.Count != 0)
      {
        userDto.InterestIds.ForEach(id =>
        {
          var userInterest = new UserInterest()
          {
            UserId = user.UserId,
            InterestId = id
          };
          user.UserInterests.Add(userInterest);
          //await _context.UserInterests.AddAsync(userInterest);
        });
      }

      // if (userDto.File != null)
      // {
      //   var imageResult = await _imageSerivice.AddImageAsync(userDto.File);
      //   if (imageResult.Error != null)
      //   {
      //     return new ResponseManager { Message = imageResult.Error.Message };
      //   }
      //   user.PhotoUrl = imageResult.SecureUrl.AbsoluteUri;
      //   user.PublicId = imageResult.PublicId;
      // }

      //await _context.SaveChangesAsync();

      await _context.SaveChangesAsync();

      return new ResponseManager
      {
        Message = "User successfully registered",
        IsSuccess = true,
        FirstName = userDto.FirstName,
        LastName = userDto.LastName,
        Token = _tokenService.CreateToken(user)

      };
    }

    catch (Exception ex)
    {
      return new ResponseManager { Message = $" Rgistration failed:\n{ex.Message}", IsSuccess = false };
    }
  }

  public async Task<MatchResponseManager> MatchUsers(string UserName)
  {
    try
    {
      var currentUser = await _context.Users.FirstOrDefaultAsync(user => user.UserName == UserName);

      if (currentUser == null)
        return new MatchResponseManager { Message = "User Not Found" };

      var allRoleUserIds = await _context.UserRoles.Select(r => r.UserId).ToListAsync();

      var userDbRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == currentUser.UserId);
      if (userDbRole == null)
        return new MatchResponseManager { Message = "User has no registered role" };
      int currentUsersRoleId = userDbRole.RoleId;

      var currentUsersInterestIds = await _context.UserInterests
                              .Where(ui => ui.UserId == currentUser.UserId)
                              .Select(ui => ui.InterestId)
                              .ToListAsync();

      if (currentUsersInterestIds.Count == 0)
        return new MatchResponseManager { Message = "No registered interest found for the user" };

      var matchedUsersId = await _context.UserInterests
                          .Where(ui => currentUsersInterestIds
                          .Contains(ui.InterestId) && ui.UserId != currentUser.UserId)
                          .Select(ui => ui.UserId)
                          .Distinct()
                          .ToListAsync();

      var matchedUserRoles = await _context.UserRoles
                              .Where(ur => matchedUsersId.Contains(ur.UserId))
                              .ToListAsync();

      var finalMatchedUsersId = matchedUserRoles
                                .Where(m => m.RoleId != currentUsersRoleId)
                                .Select(ur => ur.UserId)
                                .ToList();


      if (finalMatchedUsersId.Count == 0)
        return new MatchResponseManager
        { Message = "No matched user found", IsSuccess = true };

      var matchedUserDetails = await _context.Users
                                  .Where(user => finalMatchedUsersId
                                  .Contains(user.UserId))
                                  .ToListAsync();

      var matchedUserInterests = await _context.UserInterests
                                .Where(ui => finalMatchedUsersId
                                .Contains(ui.UserId))
                                .ToListAsync();

      var interests = await _context.Interests.ToListAsync();

      var mappedInterestNames = matchedUserInterests
                              .GroupBy(ui => ui.UserId)
                              .ToDictionary(g => g.Key, g =>
                              g.Select(ui => interests
                              .FirstOrDefault(interest => interest.InterestId == ui.InterestId)?.InterestName)
                              .Where(n => n != null).Cast<string>()
                              );

      return new MatchResponseManager
      {
        Message = $"You have {finalMatchedUsersId.Count} matches",
        IsSuccess = true,
        MatchedUsers = matchedUserDetails.Select(user => new MatchedUsersDto
        {
          FirstName = user.FirstName,
          LastName = user.LastName,
          Description = user.Description,
          Interests = mappedInterestNames.TryGetValue(user.UserId, out IEnumerable<string>? value)
                        ? value.ToList() : []
        }).ToList()
      };
    }
    catch (Exception ex)
    {
      return new MatchResponseManager { Message = $"{ex.Message}" };
    }
  }

  public async Task<AppUser> GetUserById(int id)
  {
    var userById = await _context.Users.FindAsync(id);
    if (userById == null) return null!;
    return userById;
  }

  public async Task<AppUser> GetUserByUsername(string userName)
  {
    var userByUsername = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    if (userByUsername == null) return null!;
    return userByUsername;
  }
}
