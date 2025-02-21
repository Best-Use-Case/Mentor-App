using API.Dtos.Admin;

namespace API.Interfaces;

public interface IAdminRepository
{
    Task<bool> AddDegree(DegreeDTO degree);
    Task<bool> AddInterest(AddInterestDto interest);
    Task<bool> AddRole(RoleDTO role);
    Task<bool> UpdateDegree(DegreeDTO degree);


}






