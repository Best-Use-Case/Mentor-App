using API.Dtos;
using API.Repository.AccountRepository;
using API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class AccountController
              (IAccountRepository accountRepo,
               ILogger<AccountController> log) : ControllerBase
{
    private readonly IAccountRepository _accountRepo = accountRepo;
    private readonly ILogger<AccountController> _log = log;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _accountRepo.Register(registerDto);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        _log.LogInformation($"Registration attempt by {registerDto.UserName} failed");
        return BadRequest(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _accountRepo.Login(loginDto);
        if (result.IsSuccess) return Ok(result);

        _log.LogInformation($"Login attempt by {loginDto.UserName} failed");
        return Unauthorized(result);
    }

    // Github Login 
    // [HttpPost("github-login")]
    // public async Task<ActionResult<ResponseManager>> GithubLogin(string accessToken)
    // {
    //     // Get the secret-keys from appsettings.json using IConfiguration and concaticate them using pipe |
    //     // Verify the access-token using httpClient and its method GetAsync and as parameter for this method
    //     // the -- the concaticated keys and the access-token from Github 

    //     // Steps 
    //     /*
    //       1. Generate a ClientId and clientSecret from Github
    //       2. On the settings page, create a new OAuth App. 
    //       3. When setting up the OAuth app, the values should be
    //            - Homepage URL: https://localhost:3000/
    //            - Authorization callback URL: https://localhost:5001/signin-github
    //       4. Configure Github Auth Provider
    //         - dotnet add package AspNet.AspNet.Security.Outh.GitHub
    //         - dotnet add package OctoKit ---???
    //     */
    // }
}
