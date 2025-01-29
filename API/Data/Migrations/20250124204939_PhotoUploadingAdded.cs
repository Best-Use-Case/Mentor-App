using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class PhotoUploadingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 24, 21, 49, 37, 750, DateTimeKind.Local).AddTicks(7965), new DateTime(2025, 1, 24, 21, 49, 37, 745, DateTimeKind.Local).AddTicks(2750) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 24, 21, 49, 37, 750, DateTimeKind.Local).AddTicks(9695), new DateTime(2025, 1, 24, 21, 49, 37, 750, DateTimeKind.Local).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 24, 21, 49, 37, 750, DateTimeKind.Local).AddTicks(9705), new DateTime(2025, 1, 24, 21, 49, 37, 750, DateTimeKind.Local).AddTicks(9703) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PublicId" },
                values: new object[] { new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 66, 115, 84, 111, 113, 54, 74, 84, 116, 115, 43, 89, 87, 120, 121, 53, 57, 80, 65, 87, 80, 83, 112, 101, 89, 49, 74, 101, 101, 99, 116, 98, 43, 77, 68, 47, 43, 114, 118, 117, 119, 98, 51, 82, 119, 47, 70, 108, 75, 66, 48, 112, 67, 112, 89, 115, 81, 117, 83, 55, 68, 117, 71, 97, 81, 61, 61 }, "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PublicId" },
                values: new object[] { new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 74, 102, 69, 80, 52, 55, 108, 65, 70, 52, 85, 112, 119, 121, 117, 57, 67, 89, 121, 56, 120, 118, 56, 108, 112, 48, 53, 48, 72, 84, 47, 100, 71, 81, 109, 53, 107, 43, 65, 66, 48, 84, 85, 114, 110, 65, 120, 107, 97, 102, 104, 57, 78, 90, 84, 71, 52, 48, 116, 54, 52, 118, 99, 102, 119, 61, 61 }, "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PublicId" },
                values: new object[] { new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 76, 105, 118, 65, 113, 71, 49, 117, 113, 109, 109, 99, 51, 118, 111, 55, 121, 73, 48, 120, 87, 86, 68, 113, 105, 85, 43, 84, 48, 66, 78, 98, 68, 85, 82, 120, 77, 54, 90, 50, 115, 83, 72, 87, 106, 78, 78, 73, 90, 53, 72, 98, 84, 79, 104, 79, 49, 53, 57, 120, 68, 80, 106, 70, 103, 61, 61 }, "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PublicId" },
                values: new object[] { new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 68, 116, 110, 98, 112, 69, 56, 108, 89, 107, 54, 108, 71, 103, 117, 77, 43, 121, 55, 87, 54, 119, 117, 101, 51, 68, 52, 88, 79, 121, 65, 43, 83, 50, 110, 104, 87, 103, 75, 120, 97, 76, 112, 47, 75, 104, 106, 99, 102, 114, 72, 79, 100, 47, 68, 53, 118, 107, 74, 87, 56, 97, 54, 116, 81, 61, 61 }, "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PublicId" },
                values: new object[] { new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 78, 49, 78, 85, 100, 121, 98, 76, 107, 54, 122, 71, 99, 75, 108, 122, 52, 57, 54, 104, 71, 88, 90, 66, 100, 90, 77, 121, 115, 84, 82, 70, 84, 47, 77, 52, 110, 90, 100, 73, 81, 84, 84, 51, 85, 50, 53, 43, 117, 116, 114, 47, 65, 66, 107, 76, 110, 108, 65, 89, 66, 71, 99, 72, 81, 61, 61 }, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(8045), new DateTime(2025, 1, 21, 22, 38, 47, 492, DateTimeKind.Local).AddTicks(445) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9747), new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9756), new DateTime(2025, 1, 21, 22, 38, 47, 495, DateTimeKind.Local).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 74, 53, 86, 72, 48, 101, 87, 82, 104, 80, 77, 99, 66, 121, 103, 114, 74, 50, 75, 73, 113, 100, 43, 53, 55, 48, 110, 85, 84, 85, 72, 77, 86, 53, 118, 53, 66, 114, 56, 86, 82, 85, 100, 107, 110, 102, 97, 117, 109, 104, 66, 97, 70, 83, 109, 105, 49, 48, 102, 88, 69, 108, 115, 79, 81, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 76, 57, 72, 52, 67, 53, 104, 70, 85, 110, 69, 111, 113, 43, 101, 107, 65, 50, 72, 49, 113, 116, 70, 82, 118, 85, 52, 107, 53, 99, 56, 70, 89, 114, 120, 89, 52, 57, 104, 111, 50, 79, 115, 116, 99, 86, 100, 105, 107, 67, 99, 74, 52, 121, 83, 52, 70, 76, 86, 89, 109, 74, 86, 86, 65, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 73, 110, 116, 52, 110, 70, 68, 107, 65, 120, 57, 57, 117, 97, 84, 73, 100, 87, 52, 50, 54, 81, 100, 98, 115, 99, 118, 85, 88, 118, 65, 89, 66, 97, 74, 103, 54, 118, 122, 87, 88, 90, 84, 109, 57, 78, 75, 111, 51, 99, 119, 114, 97, 113, 81, 65, 114, 110, 67, 118, 122, 48, 100, 120, 65, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 71, 86, 57, 118, 116, 43, 88, 77, 83, 120, 97, 109, 83, 104, 52, 117, 66, 82, 56, 97, 99, 49, 103, 122, 52, 78, 90, 47, 49, 121, 68, 116, 113, 108, 89, 103, 120, 103, 83, 79, 76, 74, 73, 84, 76, 77, 49, 51, 72, 89, 101, 98, 68, 119, 52, 117, 74, 112, 106, 83, 98, 104, 111, 102, 81, 61, 61 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: new byte[] { 65, 81, 65, 65, 65, 65, 73, 65, 65, 89, 97, 103, 65, 65, 65, 65, 69, 67, 114, 114, 88, 89, 102, 117, 53, 114, 90, 53, 73, 119, 121, 100, 51, 54, 120, 71, 87, 69, 113, 76, 112, 69, 113, 110, 66, 116, 77, 90, 90, 102, 66, 121, 84, 53, 74, 99, 43, 101, 66, 48, 98, 55, 87, 56, 85, 97, 118, 122, 97, 87, 70, 112, 112, 73, 122, 57, 116, 108, 69, 119, 101, 65, 61, 61 });
        }
    }
}
