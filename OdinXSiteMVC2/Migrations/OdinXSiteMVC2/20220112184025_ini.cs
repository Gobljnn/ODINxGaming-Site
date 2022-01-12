using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Exec",
                columns: table => new
                {
                    execID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    execFirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    execLastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    execGamingTag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    favGame = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    execTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    execHierarchy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    loginAmt = table.Column<int>(type: "int", nullable: true),
                    execPic = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exec", x => x.execID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    imageID = table.Column<int>(type: "int", nullable: false),
                    imageString = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userImage_Exec_userID",
                        column: x => x.userID,
                        principalTable: "Exec",
                        principalColumn: "execID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execPic", "execTitle", "favGame", "loginAmt", "username" },
                values: new object[] { 1, "Dammy", "Gobljnn", "Founding", "Adebayo", null, "Programmer", "OW", null, "Gobljnn" });

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execPic", "execTitle", "favGame", "loginAmt", "username" },
                values: new object[] { 2, "Kitan", "Kitan3000", "Founding", "Adebowale", null, "Photographer", "COD", null, "Kitan3000" });

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execPic", "execTitle", "favGame", "loginAmt", "username" },
                values: new object[] { 3, "Nathan", "Fishboy8383", "Founding", "Stayer", null, "Community Manager", "League", null, "Fishboy8383" });

            migrationBuilder.CreateIndex(
                name: "IX_userImage_userID",
                table: "userImage",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userImage");

            migrationBuilder.DropTable(
                name: "Exec");
        }
    }
}
