using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.DegreeId);
                });

            migrationBuilder.CreateTable(
                name: "FieldOfInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_FieldOfInterests_FieldOfInterestId",
                        column: x => x.FieldOfInterestId,
                        principalTable: "FieldOfInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    WorkExpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jobtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => new { x.UserId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "UserId", "Description", "FirstName", "Gender", "LastName", "PasswordHash", "PasswordSalt", "PhotoUrl", "PublicId", "UserName" },
                values: new object[,]
                {
                    { 1, "I'm admin", "Admin", "Female", "Admin", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 80, 108, 89, 55, 113, 49, 116, 84, 48, 81, 114, 103, 54, 67, 107, 103, 72, 49, 82, 82, 50, 118, 86, 75, 99, 66, 116, 86, 82, 48, 71, 89, 56, 70, 85, 76, 111, 122, 70, 87, 113, 71, 49, 105, 122, 121, 51, 56, 119, 77, 90, 43, 100, 57, 102, 69, 80, 67, 54, 70, 98, 57, 88, 87, 103, 61, 61 }, new byte[0], "", "", "Admin@gmail.com" },
                    { 2, "mentor description...", "Mentor1", "Male", "ment1", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 66, 53, 109, 119, 55, 57, 50, 110, 121, 48, 74, 119, 52, 109, 84, 66, 56, 99, 77, 104, 71, 68, 55, 87, 109, 105, 50, 98, 74, 115, 112, 43, 78, 52, 55, 112, 104, 89, 105, 102, 82, 80, 88, 55, 102, 66, 53, 86, 122, 81, 74, 66, 90, 111, 82, 120, 66, 113, 67, 79, 68, 111, 73, 78, 103, 61, 61 }, new byte[0], "https://picsum.photos/200", "", "mentor1@gmail.com" },
                    { 3, "stud description,", "Student1", "Male", "stud1VGS", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 71, 87, 67, 51, 49, 48, 76, 74, 102, 122, 56, 100, 101, 74, 74, 115, 72, 52, 66, 56, 73, 47, 86, 52, 52, 83, 107, 99, 87, 70, 65, 49, 102, 75, 120, 104, 120, 74, 73, 77, 71, 80, 108, 85, 108, 80, 56, 77, 51, 98, 79, 71, 90, 51, 66, 100, 103, 86, 57, 99, 104, 77, 88, 122, 103, 61, 61 }, new byte[0], "https://picsum.photos/200", "", "student1@gmail.com" },
                    { 4, "mentor description...", "Mentor2", "Female", "ment2", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 77, 116, 50, 50, 86, 106, 100, 52, 113, 119, 57, 97, 48, 71, 114, 98, 83, 88, 114, 90, 83, 80, 89, 122, 105, 117, 100, 79, 111, 84, 88, 50, 50, 56, 116, 52, 78, 57, 119, 119, 82, 118, 114, 65, 69, 73, 100, 84, 106, 78, 116, 49, 106, 90, 97, 73, 55, 116, 118, 54, 53, 116, 66, 101, 81, 61, 61 }, new byte[0], "https://picsum.photos/200", "", "mentor2@gmail.com" },
                    { 5, "stud description", "Student2", "Male", "studVGS2", new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 78, 80, 86, 118, 70, 90, 117, 72, 104, 118, 47, 56, 50, 88, 76, 122, 118, 108, 48, 97, 117, 82, 43, 53, 108, 104, 68, 77, 83, 53, 101, 65, 121, 101, 122, 78, 76, 102, 80, 53, 111, 107, 108, 82, 49, 68, 101, 100, 119, 119, 75, 107, 88, 99, 111, 86, 72, 76, 73, 100, 111, 81, 43, 67, 119, 61, 61 }, new byte[0], "https://picsum.photos/200", "", "student2@gmail.com" }
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
                    { 1, 1, new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(4490), "school-name", new DateTime(2025, 2, 3, 11, 5, 54, 939, DateTimeKind.Local).AddTicks(8106), "Oslo", 2 },
                    { 2, 2, new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6216), "school-name", new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6199), "Bergen", 3 },
                    { 3, 3, new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6224), "school-name", new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6222), "Stavanger", 4 }
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
