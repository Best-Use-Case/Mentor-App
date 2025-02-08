using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Dtos;
using API.Models;
using API.Services;
using API.Utils;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.AccountRepository;

public interface IAccountRepository
{
    Task<ResponseManager> Register(RegisterDto registerDto);
    Task<ResponseManager> Login(LoginDto loginDto);

}

public class AccountRepository(DataContext context, ITokenService tokenService) : IAccountRepository
{
    public async Task<ResponseManager> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto))
        {
            return new ResponseManager
            {
                Message = $"A user with {registerDto.UserName} found - Go to " +
                          $"the login page!",
                IsSuccess = false
            };
        }

        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            return new ResponseManager
            {
                Message = "Passwords do not match",
                IsSuccess = false
            };
        }

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            UserName = registerDto.UserName.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);
        var result = await context.SaveChangesAsync() > 0;
        if (!result)
        {
            return new ResponseManager
            {
                Message = "Problem creating a user",
                IsSuccess = false
            };
        }

        return new ResponseManager
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Message = "Registration succeeded",
            IsSuccess = true
        };
    }


    public async Task<ResponseManager> Login(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
        if (user is null)
        {
            return new ResponseManager
            {
                Message = "Invalid username or password",
                IsSuccess = false
            };
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
                return new ResponseManager
                {
                    Message = "Invalid username or password",
                    IsSuccess = false
                };
        }

        return new ResponseManager
        {
            UserName = user.UserName,
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            // Description = user.Description, since not all users have these fields registered
            // Gender = user.Gender,
            Token = tokenService.CreateToken(user),
            Role = GetUserRoles(user.UserId),
            Message = "Login succeeded",
            IsSuccess = true

        };

    }

    private async Task<bool> UserExists(RegisterDto registerDto)
    {
        return await context.Users.AnyAsync(u => u.UserName == registerDto.UserName.ToLower());

    }

    private List<string> GetUserRoles(int userId)
    {
        try
        {
            var userRoles = context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();
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
            return ["No role found for the user"];
        }
    }


}
