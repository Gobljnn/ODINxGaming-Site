using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class dbchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userImage_Exec_userID",
                table: "userImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userImage",
                table: "userImage");

            migrationBuilder.RenameTable(
                name: "userImage",
                newName: "UserFiles");

            migrationBuilder.RenameColumn(
                name: "imageString",
                table: "UserFiles",
                newName: "imagePath");

            migrationBuilder.RenameIndex(
                name: "IX_userImage_userID",
                table: "UserFiles",
                newName: "IX_UserFiles_userID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFiles",
                table: "UserFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFiles_Exec_userID",
                table: "UserFiles",
                column: "userID",
                principalTable: "Exec",
                principalColumn: "execID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFiles_Exec_userID",
                table: "UserFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFiles",
                table: "UserFiles");

            migrationBuilder.RenameTable(
                name: "UserFiles",
                newName: "userImage");

            migrationBuilder.RenameColumn(
                name: "imagePath",
                table: "userImage",
                newName: "imageString");

            migrationBuilder.RenameIndex(
                name: "IX_UserFiles_userID",
                table: "userImage",
                newName: "IX_userImage_userID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userImage",
                table: "userImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userImage_Exec_userID",
                table: "userImage",
                column: "userID",
                principalTable: "Exec",
                principalColumn: "execID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
