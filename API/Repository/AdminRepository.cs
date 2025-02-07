using API.Data;
using API.Dtos.Admin;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class AdminRepository(DataContext context) : IAdminRepository
{
    public async Task<bool> AddDegree(DegreeDTO degree)
    {
        try
        {
            var degreeDb = await context.Degrees.Select(d => d.DegreeName).ToListAsync();
            if (!string.IsNullOrEmpty(degree.DegreeName))
            {
                var result = degreeDb.Contains(degree.DegreeName);
                if (!result)
                {
                    var newDegree = new Degree
                    {
                        DegreeName = degree.DegreeName
                    };
                    context.Degrees.Add(newDegree);
                }
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
            var interestDb = await context.Interests.Select(x => x.InterestName).ToListAsync();
            if (!string.IsNullOrEmpty(interestDto.InterestName))
            {
                var result = interestDb.Contains(interestDto.InterestName);
                if (!result)
                {
                    var newInt = new Interest
                    {
                        InterestName = interestDto.InterestName,
                        FieldOfInterestId = interestDto.FieldOfInterestId,
                    };
                    context.Interests.Add(newInt);
                }
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
            var rolesDb = await context.AppRoles.Select(x => x.RoleName).ToListAsync();
            if (!string.IsNullOrEmpty(role.RoleName))
            {
                var result = rolesDb.Contains(role.RoleName);
                if (!result)
                {
                    var newRole = new AppRole
                    {
                        RoleName = role.RoleName,
                    };
                    context.AppRoles.Add(newRole);
                }
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

