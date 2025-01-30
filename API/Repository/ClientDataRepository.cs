using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;


public class ClientDataRepository(DataContext context) : IClientDataRepository
{
  public async Task<List<Degree>> GetDegreesAsync()
  {
    return await context.Degrees.ToListAsync();
  }

  public async Task<List<FieldOfInterest>> GetFieldOfInterestsAsync()
  {
    return await context.FieldOfInterests.Include(b => b.Interests).ToListAsync();
  }

  public async Task<List<AppRole>> GetRolesAsync()
  {
    return await context.AppRoles.ToListAsync();
  }

}

public record FieldOfInterestDto
{
  public int Id { get; set; }
  public string Category { get; set; } = string.Empty;
  public List<InterestDto> Interests { get; set; } = [];
}

public record InterestDto
{
  public int InterestId { get; set; }
  public string InterestName { get; set; } = string.Empty;
}

