using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Exec_UsersexecID",
                table: "UserFiles");

            migrationBuilder.DropIndex(
                name: "IX_UserFiles_UsersexecID",
                table: "UserFiles");

            migrationBuilder.DropColumn(
                name: "UsersexecID",
                table: "UserFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersexecID",
                table: "UserFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_UsersexecID",
                table: "UserFiles",
                column: "UsersexecID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_Exec_UsersexecID",
                table: "UserFiles",
                column: "UsersexecID",
                principalTable: "Exec",
                principalColumn: "execID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
