using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Advance_SQL_SERVER_with_API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToStudentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: new Guid("2bd9e348-924e-485c-8265-913449564e15"));

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: new Guid("fff351b6-14f2-4e01-945d-398a92800d6d"));

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "age", "name" },
                values: new object[,]
                {
                    { new Guid("19564871-b6a2-4a05-86f9-f2f96871eed1"), 21, "Test" },
                    { new Guid("c37c1af0-5c94-448b-b3ac-05c6f1a12231"), 22, "Test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: new Guid("19564871-b6a2-4a05-86f9-f2f96871eed1"));

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "id",
                keyValue: new Guid("c37c1af0-5c94-448b-b3ac-05c6f1a12231"));

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "age", "name" },
                values: new object[,]
                {
                    { new Guid("2bd9e348-924e-485c-8265-913449564e15"), 21, "Test" },
                    { new Guid("fff351b6-14f2-4e01-945d-398a92800d6d"), 22, "Test2" }
                });
        }
    }
}
