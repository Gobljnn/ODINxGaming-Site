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
                name: "NewReg",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewReg", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    UsersexecID = table.Column<int>(type: "int", nullable: true),
                    imageName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFiles_Exec_UsersexecID",
                        column: x => x.UsersexecID,
                        principalTable: "Exec",
                        principalColumn: "execID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_UserFiles_UsersexecID",
                table: "UserFiles",
                column: "UsersexecID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewReg");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "Exec");
        }
    }
}
