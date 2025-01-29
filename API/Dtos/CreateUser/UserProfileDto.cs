using System;
using API.Models;

namespace API.Dtos.CreateUser;

public class UserProfileDto
{
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public List<WorkExperience> WorkExperiences { get; set; } = [];
  public List<Education> Educations { get; set; } = [];
  public List<Interest> Interests { get; set; } = [];


}
