using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations
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
                    execTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    execHierarchy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loginAmt = table.Column<int>(type: "int", nullable: true),
                    lastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exec", x => x.execID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exec");
        }
    }
}
