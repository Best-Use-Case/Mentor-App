using System.Text;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
              optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

       }
       protected override void OnModelCreating(ModelBuilder builder)
       {

              base.OnModelCreating(builder);



              var hasher = new PasswordHasher<AppUser>();


              // Seed roles 
              var appRoles = new List<AppRole>()
              {
                     new() { RoleId = 1, RoleName = "Admin" },
                     new() { RoleId = 2, RoleName = "Mentor" },
                     new() { RoleId = 3, RoleName = "Student" }
              };
              builder.Entity<AppRole>().HasData(appRoles);


              var users = new List<AppUser>
              {
                     new() {UserId = 1, UserName = "Admin@gmail.com",
                            FirstName = "Admin",LastName = "Admin",
                            Gender = "Female", Description = "I'm admin",
                            PasswordHash = Encoding.UTF8.GetBytes(hasher.HashPassword(null!, "Password123")),
                     },
                     new() {UserId = 2, UserName = "mentor1@gmail.com", FirstName = "Mentor1", LastName="ment1",
                            PasswordHash = Encoding.UTF8.GetBytes(hasher.HashPassword(null!, "Password123")),
                            Gender = "Male", Description = "mentor description...", PhotoUrl = "https://picsum.photos/200"
                     },
                     new() {UserId = 3, UserName = "student1@gmail.com", FirstName = "Student1", LastName = "stud1VGS",
                            PasswordHash = Encoding.UTF8.GetBytes(hasher.HashPassword(null!, "Password123")),
                            Gender = "Male", Description = "stud description,", PhotoUrl = "https://picsum.photos/200"
                     },
                     new() {UserId = 4, UserName = "mentor2@gmail.com", FirstName = "Mentor2", LastName = "ment2",
                            PasswordHash = Encoding.UTF8.GetBytes(hasher.HashPassword(null!, "Password123")),
                            Gender = "Female", Description = "mentor description...", PhotoUrl = "https://picsum.photos/200"
                     },
                     new() {UserId = 5, UserName = "student2@gmail.com", FirstName = "Student2", LastName = "studVGS2",
                            PasswordHash = Encoding.UTF8.GetBytes(hasher.HashPassword(null!, "Password123")),
                            Gender = "Male", Description = "stud description", PhotoUrl = "https://picsum.photos/200"
                     }
              };
              builder.Entity<AppUser>().HasData(users);

              var userRole = new List<UserRole>
              {
                     new() {UserId = users[0].UserId, RoleId= appRoles[0].RoleId},
                     new() {UserId = users[1].UserId, RoleId= appRoles[1].RoleId},
                     new() {UserId = users[2].UserId, RoleId= appRoles[2].RoleId},
                     new() {UserId = users[3].UserId, RoleId= appRoles[1].RoleId},
                     new() {UserId = users[4].UserId, RoleId= appRoles[2].RoleId}
              };
              builder.Entity<UserRole>().HasData(userRole);

              var interests = new List<Interest>
              {
                     new() {InterestId = 1, InterestName = "IT", FieldOfInterestId = 1},
                     new() {InterestId = 2, InterestName = "Nurse", FieldOfInterestId = 2},
                     new() {InterestId = 3, InterestName = "Public policy", FieldOfInterestId = 3},
                     new() {InterestId = 4, InterestName = "Social work", FieldOfInterestId = 4},
                     new() {InterestId = 5, InterestName = "Hotel managment", FieldOfInterestId = 5},
              };
              builder.Entity<Interest>().HasData(interests);

              // Seeding UserInterests
              var userInterests = new List<UserInterest>
              {
                     new(){UserId = users[1].UserId, InterestId = interests[0].InterestId},
                     new(){UserId = users[2].UserId, InterestId = interests[1].InterestId},
                     new(){UserId = users[3].UserId, InterestId = interests[2].InterestId},
                     new(){UserId = users[4].UserId, InterestId = interests[3].InterestId},
              };
              builder.Entity<UserInterest>().HasData(userInterests);

              // Seeding Field of interests 
              var fieldOfInterests = new List<FieldOfInterest>
              {
                     new(){Id = 1, Category = "Technology"},
                     new(){Id = 2, Category = "Health"},
                     new(){Id = 3, Category = "Politics"},
                     new(){Id = 4, Category = "Social science"},
                     new(){Id = 5, Category = "Hospitality"}
              };
              builder.Entity<FieldOfInterest>().HasData(fieldOfInterests);

              var questions = new List<Question>
              {
                     new(){QuestionId = 1, QuestionText = "Hva er den beste med jobben din?"},
                     new(){QuestionId = 2, QuestionText = "Hva er den verste med jobben din, og Hvorfor?"},
                     new(){ QuestionId = 3, QuestionText = "Hvilket fag er du mest glad i?"},
                     new(){ QuestionId = 4, QuestionText = "Hvilket fag er du mest IKKE glad i, og Hvorfor?"}
              };
              builder.Entity<Question>().HasData(questions);

              var answers = new List<Answer>
              {
                     new(){AnswerId = 1, AnswerText = "Gode kollega", QuestionId = questions[0].QuestionId,
                            UserId= users[1].UserId
                     },
                       new(){AnswerId = 2, AnswerText = "matematikk :) ", QuestionId = questions[2].QuestionId,
                            UserId= users[2].UserId
                     },
                        new(){AnswerId = 3, AnswerText = "for lite ferie :) ", QuestionId = questions[1].QuestionId,
                            UserId= users[3].UserId
                     },
                        new(){AnswerId = 4, AnswerText = "for mye teori :) ", QuestionId = questions[3].QuestionId,
                            UserId= users[4].UserId
                     },
              };
              builder.Entity<Answer>().HasData(answers);

              var industries = new List<Industry>
              {
                     new(){IndustryId = 1, IndustryName = "Barn, skole og undervisning"},
                     new(){IndustryId = 2, IndustryName = "Bygg og anlegg"},
                     new(){IndustryId = 4, IndustryName = "Helse og omsorg"},
                     new(){IndustryId = 5, IndustryName = "Industri og produksjon"},
                     new(){IndustryId = 6, IndustryName = "Konsulent og rådgiving"},
                     new(){IndustryId = 7, IndustryName = "IT"},
                     new(){IndustryId = 8, IndustryName = "Kraft og energi"},
                     new(){IndustryId = 9, IndustryName = "Maritim og offshoe"},
                     new(){IndustryId = 10, IndustryName = "Offentelig administrasjon"},
                     new(){IndustryId = 11, IndustryName = "Transport og logistikk"},
              };
              builder.Entity<Industry>().HasData(industries);

              var workExperiences = new List<WorkExperience>
              {
                     new(){WorkExpId = 1, CompanyName = "Avonova Norge", Jobtitle = "job-title",
                     IndustryId = industries[0].IndustryId, UserId = users[2].UserId
                     },
                      new(){WorkExpId = 2, CompanyName = "Innovation Norge", Jobtitle = "job-title",
                     IndustryId = industries[1].IndustryId, UserId = users[4].UserId
                     }
              };
              builder.Entity<WorkExperience>().HasData(workExperiences);

              var degrees = new List<Degree>
              {
                     new(){DegreeId = 1, DegreeName = "VGS"},
                     new(){DegreeId = 2, DegreeName = "Bachelor degree"},
                     new(){DegreeId = 3, DegreeName = "Masters degree"},
                     new(){DegreeId = 4, DegreeName = "Phd"},
              };
              builder.Entity<Degree>().HasData(degrees);

              var educations = new List<Education>
              {
                     new(){EducationId = 1, SchoolName = "school-name", StudyCity = "Oslo",
                     StartDate = DateTime.Now, EndDate = DateTime.Now, UserId = users[1].UserId,
                     DegreeId = degrees[0].DegreeId},
                     new(){EducationId = 2, SchoolName = "school-name", StudyCity = "Bergen",
                     StartDate = DateTime.Now, EndDate = DateTime.Now, UserId = users[2].UserId,
                     DegreeId = degrees[1].DegreeId},
                     new(){EducationId = 3, SchoolName = "school-name", StudyCity = "Stavanger",
                     StartDate = DateTime.Now, EndDate = DateTime.Now, UserId = users[3].UserId,
                     DegreeId = degrees[2].DegreeId},
              };
              builder.Entity<Education>().HasData(educations);




              builder.Entity<UserRole>()
                     .HasKey(k => new { k.RoleId, k.UserId });
              builder.Entity<UserInterest>()
                     .HasKey(k => new { k.UserId, k.InterestId });

              builder.Entity<Education>()
                     .HasOne(e => e.AppUser)
                     .WithMany(au => au.Educations)
                     .HasForeignKey(ed => ed.UserId)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<WorkExperience>()
                    .HasOne(e => e.AppUser)
                    .WithMany(au => au.WorkExperiences)
                    .HasForeignKey(we => we.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<AppUser>()
                     .HasMany(au => au.Answers)
                     .WithOne(a => a.AppUser)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<UserInterest>()
                     .HasOne(ui => ui.AppUser)
                     .WithMany(au => au.UserInterests)
                     .HasForeignKey(ui => ui.UserId)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<UserInterest>()
               .HasOne(ui => ui.Interest)
               .WithMany(i => i.UserInterests)
               .HasForeignKey(ui => ui.InterestId)
               .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<UserRole>()
                     .HasOne(ur => ur.AppUser)
                     .WithMany(au => au.Roles)
                     .HasForeignKey(ur => ur.UserId)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<UserRole>()
                     .HasOne(ur => ur.AppRole)
                     .WithMany(ar => ar.UserRoles)
                     .HasForeignKey(ar => ar.RoleId)
                     .OnDelete(DeleteBehavior.Cascade);


              builder.Entity<Interest>()
                     .HasOne(i => i.FieldOfInterest)
                     .WithMany(fi => fi.Interests)
                     .HasForeignKey(i => i.FieldOfInterestId)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<Answer>()
                     .HasOne(a => a.AppUser)
                     .WithMany(au => au.Answers)
                     .HasForeignKey(au => au.UserId)
                     .OnDelete(DeleteBehavior.Cascade);

       }

       public DbSet<AppUser> Users { get; set; }
       public DbSet<UserInterest> UserInterests { get; set; }
       public DbSet<Interest> Interests { get; set; }
       public DbSet<FieldOfInterest> FieldOfInterests { get; set; }
       public DbSet<AppRole> AppRoles { get; set; }
       public DbSet<UserRole> UserRoles { get; set; }
       public DbSet<Education> Educations { get; set; }
       public DbSet<WorkExperience> WorkExperiences { get; set; }
       public DbSet<Industry> Industries { get; set; }
       public DbSet<Degree> Degrees { get; set; }
       public DbSet<Question> Questions { get; set; }
       public DbSet<Answer> Answers { get; set; }

}
