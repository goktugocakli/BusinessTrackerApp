using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessTrackerApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59e1d439-c62f-42fe-918f-8dac87022062", null, "Team Leader", "TEAM LEADER" },
                    { "837721ab-ec11-442a-bb6f-e153030171c4", null, "Admin", "ADMIN" },
                    { "c5a99608-7fd0-4c63-86fd-9dc8b49c6f46", null, "Department Manager", "DEPARTMENT MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59e1d439-c62f-42fe-918f-8dac87022062");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837721ab-ec11-442a-bb6f-e153030171c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a99608-7fd0-4c63-86fd-9dc8b49c6f46");
        }
    }
}
