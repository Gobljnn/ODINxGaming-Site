using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exec",
                columns: table => new
                {
                    execID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    execFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    execLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    execGamingTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    favGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    execTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    execHierarchy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loginAmt = table.Column<int>(type: "int", nullable: true),
                    lastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exec", x => x.execID);
                });

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execTitle", "favGame", "lastLogin", "loginAmt", "username" },
                values: new object[] { 1, "Dammy", "Gobljnn", "Founding", "Adebayo", "Programmer", "OW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gobljnn" });

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execTitle", "favGame", "lastLogin", "loginAmt", "username" },
                values: new object[] { 2, "Kitan", "Kitan3000", "Founding", "Adebowale", "Photographer", "COD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kitan3000" });

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execTitle", "favGame", "lastLogin", "loginAmt", "username" },
                values: new object[] { 3, "Nathan", "Fishboy8383", "Founding", "Stayer", "Community Manager", "League", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fishboy8383" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exec");
        }
    }
}
