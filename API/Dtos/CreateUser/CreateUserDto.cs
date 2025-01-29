using System;
using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Dtos.CreateUser;

public record CreateUserDto
{
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Description { get; set; }
    public required string Gender { get; set; }
    public required int RoleId { get; set; }
    public required List<Interest> Interests { get; set; }
    public required List<Education> Educations { get; set; }
    public required List<Answer> Answers { get; set; }
    public required List<WorkExperience> WorkExperiences { get; set; }
    public string PhotoUrl { get; set; } = string.Empty; // To be done later 


}
