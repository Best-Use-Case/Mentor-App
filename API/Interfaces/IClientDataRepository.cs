using API.Models;

namespace API.Interfaces;

public interface IClientDataRepository
{
  Task<List<AppRole>> GetRolesAsync();
  Task<List<Degree>> GetDegreesAsync();
  Task<List<FieldOfInterest>> GetFieldOfInterestsAsync();

}

