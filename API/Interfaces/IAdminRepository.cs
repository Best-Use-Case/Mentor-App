
using API.Dtos.Admin;

namespace API.Interfaces;

public interface IAdminRepository
{
    // all about interests 
    Task<bool> AddDegree(DegreeDTO degree);
    Task<bool> UpdateDegree(DegreeDTO degree);
    Task<bool> RemoveDegree(int id);

    // all about interests

    Task<bool> AddInterest(InterestDTO interest);

    // all about role
    Task<bool> AddRole(RoleDTO role);


}






