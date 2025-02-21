using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class MessageClassAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateMessageSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 2, 7, 12, 54, 37, 345, DateTimeKind.Local).AddTicks(511), new DateTime(2025, 2, 7, 12, 54, 37, 339, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 2, 7, 12, 54, 37, 345, DateTimeKind.Local).AddTicks(2946), new DateTime(2025, 2, 7, 12, 54, 37, 345, DateTimeKind.Local).AddTicks(2927) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 2, 7, 12, 54, 37, 345, DateTimeKind.Local).AddTicks(2959), new DateTime(2025, 2, 7, 12, 54, 37, 345, DateTimeKind.Local).AddTicks(2955) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 79, 88, 79, 90, 107, 54, 115, 113, 56, 78, 65, 98, 90, 83, 75, 114, 90, 48, 107, 52, 55, 120, 105, 112, 110, 50, 72, 78, 50, 76, 73, 48, 89, 83, 77, 66, 118, 108, 115, 107, 98, 72, 50, 53, 102, 121, 106, 71, 74, 103, 114, 67, 86, 48, 54, 111, 75, 85, 48, 107, 43, 47, 109, 68, 103, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 77, 117, 82, 49, 110, 55, 103, 87, 80, 79, 50, 97, 87, 118, 111, 103, 118, 121, 47, 56, 53, 116, 68, 75, 49, 49, 101, 56, 121, 98, 112, 65, 102, 98, 50, 48, 120, 81, 57, 113, 67, 103, 100, 57, 65, 76, 102, 86, 116, 66, 102, 115, 84, 54, 70, 88, 55, 49, 75, 77, 100, 113, 120, 80, 103, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 65, 103, 57, 71, 43, 109, 110, 121, 66, 69, 73, 55, 72, 78, 85, 56, 80, 111, 88, 49, 52, 82, 54, 103, 104, 80, 55, 114, 109, 118, 115, 72, 117, 86, 53, 71, 83, 110, 104, 80, 104, 117, 102, 53, 108, 73, 72, 47, 73, 120, 54, 87, 57, 108, 81, 51, 48, 51, 68, 73, 77, 109, 103, 50, 65, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 75, 112, 83, 74, 102, 47, 85, 116, 65, 65, 69, 101, 57, 65, 70, 109, 47, 116, 90, 66, 112, 67, 74, 121, 98, 90, 75, 103, 78, 76, 102, 65, 117, 82, 80, 87, 71, 90, 90, 101, 67, 117, 49, 79, 54, 51, 72, 67, 82, 77, 107, 52, 75, 115, 87, 82, 72, 50, 103, 77, 50, 109, 112, 112, 81, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 73, 119, 107, 122, 112, 119, 86, 100, 74, 120, 87, 51, 108, 50, 72, 48, 65, 116, 75, 102, 81, 69, 77, 48, 109, 49, 76, 47, 54, 85, 98, 53, 116, 119, 43, 78, 72, 98, 115, 111, 85, 115, 88, 101, 77, 70, 47, 74, 86, 100, 52, 72, 74, 65, 74, 48, 54, 100, 67, 113, 79, 79, 57, 69, 119, 61, 61 });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(4490), new DateTime(2025, 2, 3, 11, 5, 54, 939, DateTimeKind.Local).AddTicks(8106) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6216), new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6224), new DateTime(2025, 2, 3, 11, 5, 54, 945, DateTimeKind.Local).AddTicks(6222) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 80, 108, 89, 55, 113, 49, 116, 84, 48, 81, 114, 103, 54, 67, 107, 103, 72, 49, 82, 82, 50, 118, 86, 75, 99, 66, 116, 86, 82, 48, 71, 89, 56, 70, 85, 76, 111, 122, 70, 87, 113, 71, 49, 105, 122, 121, 51, 56, 119, 77, 90, 43, 100, 57, 102, 69, 80, 67, 54, 70, 98, 57, 88, 87, 103, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 66, 53, 109, 119, 55, 57, 50, 110, 121, 48, 74, 119, 52, 109, 84, 66, 56, 99, 77, 104, 71, 68, 55, 87, 109, 105, 50, 98, 74, 115, 112, 43, 78, 52, 55, 112, 104, 89, 105, 102, 82, 80, 88, 55, 102, 66, 53, 86, 122, 81, 74, 66, 90, 111, 82, 120, 66, 113, 67, 79, 68, 111, 73, 78, 103, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 71, 87, 67, 51, 49, 48, 76, 74, 102, 122, 56, 100, 101, 74, 74, 115, 72, 52, 66, 56, 73, 47, 86, 52, 52, 83, 107, 99, 87, 70, 65, 49, 102, 75, 120, 104, 120, 74, 73, 77, 71, 80, 108, 85, 108, 80, 56, 77, 51, 98, 79, 71, 90, 51, 66, 100, 103, 86, 57, 99, 104, 77, 88, 122, 103, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 77, 116, 50, 50, 86, 106, 100, 52, 113, 119, 57, 97, 48, 71, 114, 98, 83, 88, 114, 90, 83, 80, 89, 122, 105, 117, 100, 79, 111, 84, 88, 50, 50, 56, 116, 52, 78, 57, 119, 119, 82, 118, 114, 65, 69, 73, 100, 84, 106, 78, 116, 49, 106, 90, 97, 73, 55, 116, 118, 54, 53, 116, 66, 101, 81, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 78, 80, 86, 118, 70, 90, 117, 72, 104, 118, 47, 56, 50, 88, 76, 122, 118, 108, 48, 97, 117, 82, 43, 53, 108, 104, 68, 77, 83, 53, 101, 65, 121, 101, 122, 78, 76, 102, 80, 53, 111, 107, 108, 82, 49, 68, 101, 100, 119, 119, 75, 107, 88, 99, 111, 86, 72, 76, 73, 100, 111, 81, 43, 67, 119, 61, 61 });
        }
    }
}
