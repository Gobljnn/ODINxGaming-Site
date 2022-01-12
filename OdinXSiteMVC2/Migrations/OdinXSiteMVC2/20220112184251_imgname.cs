using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class imgname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageID",
                table: "userImage");

            migrationBuilder.AddColumn<string>(
                name: "imageName",
                table: "userImage",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageName",
                table: "userImage");

            migrationBuilder.AddColumn<int>(
                name: "imageID",
                table: "userImage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
