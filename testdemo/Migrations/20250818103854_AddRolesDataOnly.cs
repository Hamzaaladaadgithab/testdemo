using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testdemo.Migrations
{
    public partial class AddRolesDataOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Sadece rolleri ekliyoruz
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c7a2b3f-1234-4567-89ab-1234567890ab", "2a8b9c4d-2345-5678-90cd-2345678901bc", "Admin", "ADMIN" },
                    { "3d8e4f5a-3456-6789-01de-3456789012cd", "4e9f5a6b-4567-7890-12ef-2345678901de", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Rolleri silmek için
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    "1c7a2b3f-1234-4567-89ab-1234567890ab",
                    "3d8e4f5a-3456-6789-01de-3456789012cd"
                });
        }
    }
}
