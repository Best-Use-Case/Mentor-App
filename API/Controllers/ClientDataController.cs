using API.Interfaces;
using API.Models;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientDataController(IClientDataRepository clientData, IMapper mapper) : ControllerBase
{
  [HttpGet("get-degrees")]
  public async Task<ActionResult<List<Degree>>> GetDegreeList()
  {
    var degrees = await clientData.GetDegreesAsync();
    if (degrees == null) return NotFound("No degree names in Db found");
    return degrees;
  }

  [HttpGet("get-roles")]
  public async Task<ActionResult<List<AppRole>>> GetRoleList()
  {
    var roles = await clientData.GetRolesAsync();
    if (roles == null) return NotFound("No role names found in Db");
    return Ok(roles);
  }

  [HttpGet("get-interests")]
  public async Task<ActionResult<List<FieldOfInterestDto>>> GetInterestList()
  {
    var interests = await clientData.GetFieldOfInterestsAsync();
    if (interests == null) return NotFound("No interest names found in Db");

    var interestToReturn = mapper.Map<List<FieldOfInterestDto>>(interests);

    return Ok(interestToReturn);
  }

  [HttpGet("get-industries")]
  public async Task<ActionResult<Industry>> GetIndustryList()
  {
    var industries = await clientData.GetIndustriesAsync();
    if (industries.Count == 0) return NotFound("No industry found to show");
    return Ok(industries);
  }


}
