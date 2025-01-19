using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
       protected override void OnModelCreating(ModelBuilder builder)
       {
              base.OnModelCreating(builder);


              // Seed roles 
              var appRoles = new List<AppRole>()
              {
                     new() { RoleId = 1, RoleName = "Admin" },
                     new() { RoleId = 2, RoleName = "Mentor" },
                     new() { RoleId = 3, RoleName = "Student" }
              };
              builder.Entity<AppRole>().HasData(appRoles);


              // Create users 
              var users = new List<AppUser>
              {
                     new() {UserId = 1, UserName = "test1@gmail.com"},
                     new() {UserId = 2, UserName = "test2@gmail.com"},
                     new() {UserId = 3, UserName = "test3@gmail.com"},
                     new() {UserId = 4, UserName = "test4@gmail.com"},
                     new() {UserId = 5, UserName = "test5@gmail.com"}
              };
              builder.Entity<AppUser>().HasData(users);

              // Seeding UserRole
              var userRole = new List<UserRole>
              {
                     new() {UserId = users[0].UserId, RoleId= appRoles[0].RoleId},
                     new() {UserId = users[1].UserId, RoleId= appRoles[1].RoleId},
                     new() {UserId = users[2].UserId, RoleId= appRoles[2].RoleId},
                     new() {UserId = users[3].UserId, RoleId= appRoles[1].RoleId},
                     new() {UserId = users[4].UserId, RoleId= appRoles[2].RoleId}
              };
              builder.Entity<UserRole>().HasData(userRole);

              // Seeding interests
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









              builder.Entity<UserRole>()
                     .HasKey(k => new { k.RoleId, k.UserId });
              builder.Entity<UserInterest>()
                     .HasKey(k => new { k.UserId, k.InterestId });

              builder.Entity<Student>()
                     .HasMany(s => s.Educations)
                     .WithOne(ed => ed.Student)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<Mentor>()
               .HasMany(m => m.WorkExperiences)
               .WithOne(w => w.Mentor)
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

              // builder.Entity<FieldOfInterest>()
              //       .HasMany(f => f.Interests)
              //       .WithOne(i => i.FieldOfInterest)
              //       .OnDelete(DeleteBehavior.Cascade);

              builder.Entity<Interest>()
                     .HasOne(i => i.FieldOfInterest)
                     .WithMany(fi => fi.Interests)
                     .HasForeignKey(i => i.FieldOfInterestId)
                     .OnDelete(DeleteBehavior.Cascade);









       }

       public DbSet<AppUser> Users { get; set; }
       public DbSet<UserInterest> UserInterests { get; set; }
       public DbSet<Interest> Interests { get; set; }
       public DbSet<FieldOfInterest> FieldOfInterests { get; set; }
       public DbSet<AppRole> AppRoles { get; set; }
       public DbSet<UserRole> UserRoles { get; set; }
       public DbSet<Student> Students { get; set; }
       public DbSet<Mentor> Mentors { get; set; }
       public DbSet<Education> Educations { get; set; }

}
