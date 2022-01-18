using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class execbio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "Exec",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Exec",
                keyColumn: "execID",
                keyValue: "001",
                column: "bio",
                value: " Oluwadamilola Gobljnn Adebayo (Dammy), a chemical engineer, one of the co-founders of ODINxGAMING goes by the gamer His favourite genre to play is FPS, which includes a shit - ton of Overwatch and Call of Duty.He also dabbles in a bit of Rocket League buthe dog water.Gobljnn is ODINxGaming's Lead Developer and UI Support member.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bio",
                table: "Exec");
        }
    }
}
