using API.Data;
using API.Dtos.Admin;
using API.Interfaces;
using API.Models;

namespace API.Repository;

public class AdminRepository(DataContext context) : IAdminRepository
{
    public async Task<bool> AddDegree(DegreeDTO degree)
    {
        try
        {
            if (!string.IsNullOrEmpty(degree.DegreeName))
            {
                var newDegree = new Degree
                {
                    DegreeName = degree.DegreeName
                };
                context.Degrees.Add(newDegree);
            }

            if (await context.SaveChangesAsync() > 0) return true;

            return false;

        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> UpdateDegree(DegreeDTO degree)
    {
        try
        {
            if (!string.IsNullOrEmpty(degree.DegreeName))
            {
                var id = degree.DegreeId;
                var degreeFromDb = await context.Degrees.FindAsync(id);
                if (degreeFromDb == null) return false;
                degreeFromDb!.DegreeId = degree.DegreeId;
                degreeFromDb.DegreeName = degree.DegreeName;
                context.Degrees.Update(degreeFromDb);
            }
            if (await context.SaveChangesAsync() > 0) return true;

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }


    // swagger-tested
    public async Task<bool> AddInterest(AddInterestDto interestDto)
    {
        try
        {
            if (!string.IsNullOrEmpty(interestDto.InterestName))
            {
                var newInt = new Interest
                {
                    InterestName = interestDto.InterestName,
                    FieldOfInterestId = interestDto.FieldOfInterestId,
                };
                context.Interests.Add(newInt);
            }
            if (await context.SaveChangesAsync() > 0) return true;

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // swagger-tested
    public async Task<bool> AddRole(RoleDTO role)
    {
        try
        {
            if (!string.IsNullOrEmpty(role.RoleName))
            {
                var newRole = new AppRole
                {
                    RoleName = role.RoleName,
                };
                context.AppRoles.Add(newRole);
            }
            if (await context.SaveChangesAsync() > 0) return true;

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

}

