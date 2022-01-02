using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations
{
    public partial class addfavgame2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "favGame",
                table: "Exec",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exec",
                keyColumn: "execID",
                keyValue: 1,
                column: "favGame",
                value: "OW");

            migrationBuilder.UpdateData(
                table: "Exec",
                keyColumn: "execID",
                keyValue: 2,
                column: "favGame",
                value: "COD");

            migrationBuilder.UpdateData(
                table: "Exec",
                keyColumn: "execID",
                keyValue: 3,
                column: "favGame",
                value: "League");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "favGame",
                table: "Exec");
        }
    }
}
