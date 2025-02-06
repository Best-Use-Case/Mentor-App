using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public interface ITokenService
{
    string CreateToken(AppUser user);
}

public class TokenService(IConfiguration config) : ITokenService
{
    private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(config["TokenKey"]!));

    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.NameId, user.UserName),
            new(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId))
        };


        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescritor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescritor);

        return tokenHandler.WriteToken(token);


    }
}
