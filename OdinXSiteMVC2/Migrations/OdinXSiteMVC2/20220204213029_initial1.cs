using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewReg",
                keyColumn: "Id",
                keyValue: "xyz");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NewReg",
                columns: new[] { "Id", "email", "firstName", "gamerTag", "lastName", "profilePic", "role", "roleId", "userName" },
                values: new object[] { "xyz", null, "Test", null, "Admin", "../../Assets/Pic/Fishboi8383logo.jpg", null, null, null });
        }
    }
}
