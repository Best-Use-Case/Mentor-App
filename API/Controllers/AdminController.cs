using API.Dtos.Admin;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController(IAdminRepository adminRepository) : ControllerBase
    {
        [HttpPost("add-degree")]
        public async Task<IActionResult> AddDegree(DegreeDTO degreeDto)
        {
            if (string.IsNullOrEmpty(degreeDto.DegreeName)) return BadRequest("There should be a degree to add");
            var result = await adminRepository.AddDegree(degreeDto);
            if (!result) return BadRequest("Failed to add a degree");

            return Ok(result);
        }

        [HttpPost("update-degree")]
        public async Task<IActionResult> UpdateDegree(DegreeDTO degreeDto)
        {
            if (string.IsNullOrEmpty(degreeDto.DegreeName)) return BadRequest("Problem with updating degree");
            var result = await adminRepository.UpdateDegree(degreeDto);
            if (!result) return BadRequest("Failed to update a degree");

            return Ok(result);
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(RoleDTO roleDto)
        {
            if (string.IsNullOrEmpty(roleDto.RoleName))
                return BadRequest("Role name is required");
            var result = await adminRepository.AddRole(roleDto);
            if (!result) return BadRequest("Failed to create a role");

            return Ok(result);
        }

        [HttpPost("add-interest")]
        public async Task<IActionResult> AddInterest(InterestDTO interestDto)
        {
            if (string.IsNullOrEmpty(interestDto.InterestName))
                return BadRequest("Interest name is required to create an interest");
            var result = await adminRepository.AddInterest(interestDto);
            if (!result) return BadRequest("Failed to create an interest");

            return Ok(result);

        }

    }
}