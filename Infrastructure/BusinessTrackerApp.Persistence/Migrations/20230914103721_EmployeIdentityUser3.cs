using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessTrackerApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmployeIdentityUser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d32dc6c-6de9-4f15-a8df-3d3160226f24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "551d3106-b112-4d74-8f03-220367ed296e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70bc42a8-2c53-4080-b719-e4cad353e630");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "NameSurname");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "218e0d76-8240-410c-bdf3-40e8d8c4303e", null, "Department Manager", "DEPARTMENT MANAGER" },
                    { "6024c314-2dc1-4021-8bce-7aa7816a3149", null, "Team Leader", "TEAM LEADER" },
                    { "967a1e3e-2622-415d-ab5e-873604ed73ec", null, "Admin", "ADMIN" },
                    { "b38f9fe3-9835-4c3e-8475-1f8a84d1c9e8", null, "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "218e0d76-8240-410c-bdf3-40e8d8c4303e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6024c314-2dc1-4021-8bce-7aa7816a3149");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967a1e3e-2622-415d-ab5e-873604ed73ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38f9fe3-9835-4c3e-8475-1f8a84d1c9e8");

            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d32dc6c-6de9-4f15-a8df-3d3160226f24", null, "Department Manager", "DEPARTMENT MANAGER" },
                    { "551d3106-b112-4d74-8f03-220367ed296e", null, "Admin", "ADMIN" },
                    { "70bc42a8-2c53-4080-b719-e4cad353e630", null, "Team Leader", "TEAM LEADER" }
                });
        }
    }
}
