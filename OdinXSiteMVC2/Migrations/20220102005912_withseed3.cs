using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations
{
    public partial class withseed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execTitle", "lastLogin", "loginAmt", "username" },
                values: new object[] { 1, "Dammy", "Gobljnn", "Founding", "Adebayo", "Programmer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gobljnn" });

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execTitle", "lastLogin", "loginAmt", "username" },
                values: new object[] { 2, "Kitan", "Kitan3000", "Founding", "Adebowale", "Photographer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kitan3000" });

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execTitle", "lastLogin", "loginAmt", "username" },
                values: new object[] { 3, "Nathan", "Fishboy8383", "Founding", "Stayer", "Community Manager", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fishboy8383" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exec",
                keyColumn: "execID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exec",
                keyColumn: "execID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exec",
                keyColumn: "execID",
                keyValue: 3);
        }
    }
}
