using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCore_3.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Programming courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Backend development");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "ASP.NET development");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Design courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "User interface design");

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "Email", "FullName", "JoinedDate" },
                values: new object[,]
                {
                    { 1, "C# Instructor", "ahmed@example.com", "Ahmed Hassan", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Backend Instructor", "mona@example.com", "Mona Ali", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "omar@example.com", "Omar Khaled", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Introduction to C#", 1, true, 0, 500m, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Basics" },
                    { 2, 1, "Advanced C# programming", 1, true, 2, 800m, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced C#" },
                    { 3, 3, "Web development using ASP.NET Core", 2, true, 1, 1000m, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core" },
                    { 4, 2, "Backend development basics", 2, false, 0, 650m, null, "Backend Fundamentals" },
                    { 5, 5, "Introduction to UI Design", 3, true, 0, 450m, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "UI Design Basics" },
                    { 6, 4, "Advanced UI Design", 3, false, 2, 900m, null, "Professional UI Design" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Programming Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Backend Development");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "ASP.NET Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Design Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "User Interface Design");
        }
    }
}
