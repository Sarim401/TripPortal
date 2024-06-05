using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripPortal.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c4ec33-ff78-4de0-a18c-06d7dc47d6a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa8767cc-d51e-4420-a082-b21137544e78");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40bfc322-13b3-4d79-8c8b-05ebc2177086", null, "student", "employee" },
                    { "ae7cbba7-5cde-4d8b-bc4c-adf96a22f8cd", null, "employee", null },
                    { "c3deb376-c7c5-4bf2-b415-7af5d66c0340", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40bfc322-13b3-4d79-8c8b-05ebc2177086");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae7cbba7-5cde-4d8b-bc4c-adf96a22f8cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3deb376-c7c5-4bf2-b415-7af5d66c0340");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94c4ec33-ff78-4de0-a18c-06d7dc47d6a2", null, "admin", "admin" },
                    { "fa8767cc-d51e-4420-a082-b21137544e78", null, "student", "student" }
                });
        }
    }
}
