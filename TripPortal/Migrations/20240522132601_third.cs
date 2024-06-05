using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripPortal.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2644ba75-caa0-40a1-9526-11db681710b3", null, "employee", "employee" },
                    { "3d974fb9-ff92-4991-94d0-c7ebcf224fa8", null, "admin", "admin" },
                    { "c33b89fe-e117-45e6-add1-ae90b485129f", null, "student", "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2644ba75-caa0-40a1-9526-11db681710b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d974fb9-ff92-4991-94d0-c7ebcf224fa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c33b89fe-e117-45e6-add1-ae90b485129f");

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
    }
}
