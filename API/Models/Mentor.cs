using System;

namespace API.Models;

public class Mentor : AppUser
{
  public List<WorkExperience> WorkExperiences { get; set; } = [];

}
