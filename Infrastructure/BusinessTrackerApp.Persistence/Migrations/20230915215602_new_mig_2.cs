using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessTrackerApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class new_mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "342599ac-5994-4922-80a1-3ac7a8337d86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45918b11-3bc4-45eb-a8f1-bce24c82cc5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cb26264-ce6c-40c0-a544-d1624403c310");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e6a391e-fbe3-4e8c-a7e4-80defeeb7d2e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1423b4af-662b-4376-932c-70d8522a31ce", null, "Employee", "EMPLOYEE" },
                    { "28adc6c2-99de-40bb-bd85-c983be020b1a", null, "Admin", "ADMIN" },
                    { "72fdb710-543f-4f37-9031-2351d2359b4c", null, "Department Manager", "DEPARTMENT MANAGER" },
                    { "e0687a77-8f78-459e-acb6-ba68a8f72300", null, "Team Leader", "TEAM LEADER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1423b4af-662b-4376-932c-70d8522a31ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28adc6c2-99de-40bb-bd85-c983be020b1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72fdb710-543f-4f37-9031-2351d2359b4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0687a77-8f78-459e-acb6-ba68a8f72300");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "342599ac-5994-4922-80a1-3ac7a8337d86", null, "Admin", "ADMIN" },
                    { "45918b11-3bc4-45eb-a8f1-bce24c82cc5b", null, "Team Leader", "TEAM LEADER" },
                    { "8cb26264-ce6c-40c0-a544-d1624403c310", null, "Employee", "EMPLOYEE" },
                    { "8e6a391e-fbe3-4e8c-a7e4-80defeeb7d2e", null, "Department Manager", "DEPARTMENT MANAGER" }
                });
        }
    }
}
