using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    DegreeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DegreeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.DegreeId);
                });

            migrationBuilder.CreateTable(
                name: "FieldOfInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IndustryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InterestName = table.Column<string>(type: "TEXT", nullable: false),
                    FieldOfInterestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_FieldOfInterests_FieldOfInterestId",
                        column: x => x.FieldOfInterestId,
                        principalTable: "FieldOfInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerText = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolName = table.Column<string>(type: "TEXT", nullable: false),
                    StudyCity = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DegreeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    WorkExpId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    Jobtitle = table.Column<string>(type: "TEXT", nullable: false),
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.WorkExpId);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    InterestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => new { x.UserId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Mentor" },
                    { 3, "Student" }
                });

            migrationBuilder.InsertData(
                table: "Degrees",
                columns: new[] { "DegreeId", "DegreeName" },
                values: new object[,]
                {
                    { 1, "VGS" },
                    { 2, "Bachelor degree" },
                    { 3, "Masters degree" },
                    { 4, "Phd" }
                });

            migrationBuilder.InsertData(
                table: "FieldOfInterests",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "Technology" },
                    { 2, "Health" },
                    { 3, "Politics" },
                    { 4, "Social science" },
                    { 5, "Hospitality" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "IndustryId", "IndustryName" },
                values: new object[,]
                {
                    { 1, "Barn, skole og undervisning" },
                    { 2, "Bygg og anlegg" },
                    { 4, "Helse og omsorg" },
                    { 5, "Industri og produksjon" },
                    { 6, "Konsulent og rådgiving" },
                    { 7, "IT" },
                    { 8, "Kraft og energi" },
                    { 9, "Maritim og offshoe" },
                    { 10, "Offentelig administrasjon" },
                    { 11, "Transport og logistikk" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "Hva er den beste med jobben din?" },
                    { 2, "Hva er den verste med jobben din, og Hvorfor?" },
                    { 3, "Hvilket fag er du mest glad i?" },
                    { 4, "Hvilket fag er du mest IKKE glad i, og Hvorfor?" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Description", "FirstName", "Gender", "LastName", "PasswordHash", "PasswordSalt", "PhotoUrl", "UserName" },
                values: new object[,]
                {
                    { 1, "I'm admin", "Admin", "Female", "Admin", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 74, 53, 86, 72, 48, 101, 87, 82, 104, 80, 77, 99, 66, 121, 103, 114, 74, 50, 75, 73, 113, 100, 43, 53, 55, 48, 110, 85, 84, 85, 72, 77, 86, 53, 118, 53, 66, 114, 56, 86, 82, 85, 100, 107, 110, 102, 97, 117, 109, 104, 66, 97, 70, 83, 109, 105, 49, 48, 102, 88, 69, 108, 115, 79, 81, 61, 61 }, new byte[0], "", "Admin@gmail.com" },
                    { 2, "mentor description...", "Mentor1", "Male", "ment1", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 76, 57, 72, 52, 67, 53, 104, 70, 85, 110, 69, 111, 113, 43, 101, 107, 65, 50, 72, 49, 113, 116, 70, 82, 118, 85, 52, 107, 53, 99, 56, 70, 89, 114, 120, 89, 52, 57, 104, 111, 50, 79, 115, 116, 99, 86, 100, 105, 107, 67, 99, 74, 52, 121, 83, 52, 70, 76, 86, 89, 109, 74, 86, 86, 65, 61, 61 }, new byte[0], "https://picsum.photos/200", "mentor1@gmail.com" },
                    { 3, "stud description,", "Student1", "Male", "stud1VGS", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 73, 110, 116, 52, 110, 70, 68, 107, 65, 120, 57, 57, 117, 97, 84, 73, 100, 87, 52, 50, 54, 81, 100, 98, 115, 99, 118, 85, 88, 118, 65, 89, 66, 97, 74, 103, 54, 118, 122, 87, 88, 90, 84, 109, 57, 78, 75, 111, 51, 99, 119, 114, 97, 113, 81, 65, 114, 110, 67, 118, 122, 48, 100, 120, 65, 61, 61 }, new byte[0], "https://picsum.photos/200", "student1@gmail.com" },
                    { 4, "mentor description...", "Mentor2", "Female", "ment2", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 71, 86, 57, 118, 116, 43, 88, 77, 83, 120, 97, 109, 83, 104, 52, 117, 66, 82, 56, 97, 99, 49, 103, 122, 52, 78, 90, 47, 49, 121, 68, 116, 113, 108, 89, 103, 120, 103, 83, 79, 76, 74, 73, 84, 76, 77, 49, 51, 72, 89, 101, 98, 68, 119, 52, 117, 74, 112, 106, 83, 98, 104, 111, 102, 81, 61, 61 }, new byte[0], "https://picsum.photos/200", "mentor2@gmail.com" },
                    { 5, "stud description", "Student2", "Male", "studVGS2", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 67, 114, 114, 88, 89, 102, 117, 53, 114, 90, 53, 73, 119, 121, 100, 51, 54, 120, 71, 87, 69, 113, 76, 112, 69, 113, 110, 66, 116, 77, 90, 90, 102, 66, 121, 84, 53, 74, 99, 43, 101, 66, 48, 98, 55, 87, 56, 85, 97, 118, 122, 97, 87, 70, 112, 112, 73, 122, 57, 116, 108, 69, 119, 101, 65, 61, 61 }, new byte[0], "https://picsum.photos/200", "student2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerText", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 1, "Gode kollega", 1, 2 },
                    { 2, "matematikk :) ", 3, 3 },
                    { 3, "for lite ferie :) ", 2, 4 },
                    { 4, "for mye teori :) ", 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "DegreeId", "EndDate", "SchoolName", "StartDate", "StudyCity", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(8045), "school-name", new DateTime(2025, 1, 21, 22, 38, 47, 492, DateTimeKind.Local).AddTicks(445), "Oslo", 2 },
                    { 2, 2, new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9747), "school-name", new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9729), "Bergen", 3 },
                    { 3, 3, new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9756), "school-name", new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9754), "Stavanger", 4 }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "FieldOfInterestId", "InterestName" },
                values: new object[,]
                {
                    { 1, 1, "IT" },
                    { 2, 2, "Nurse" },
                    { 3, 3, "Public policy" },
                    { 4, 4, "Social work" },
                    { 5, 5, "Hotel managment" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 3 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "WorkExperiences",
                columns: new[] { "WorkExpId", "CompanyName", "IndustryId", "Jobtitle", "UserId" },
                values: new object[,]
                {
                    { 1, "Avonova Norge", 1, "job-title", 3 },
                    { 2, "Innovation Norge", 2, "job-title", 5 }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "InterestId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_DegreeId",
                table: "Educations",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UserId",
                table: "Educations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_FieldOfInterestId",
                table: "Interests",
                column: "FieldOfInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestId",
                table: "UserInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_IndustryId",
                table: "WorkExperiences",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_UserId",
                table: "WorkExperiences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FieldOfInterests");
        }
    }
}
