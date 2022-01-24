using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinXSiteMVC2.Migrations.OdinXSiteMVC2
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Exec",
                columns: table => new
                {
                    execID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exec", x => x.execID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    roleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExecSocial",
                columns: table => new
                {
                    socialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    execId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    execName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    discordName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    discordLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ttvlink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    instaLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    twitLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tiktokLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    scLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    live = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecSocial", x => x.socialID);
                    table.ForeignKey(
                        name: "FK_ExecSocial_Exec_execId",
                        column: x => x.execId,
                        principalTable: "Exec",
                        principalColumn: "execID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NewReg",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    firstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    profilePic = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gamerTag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    roleId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewReg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewReg_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imageName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFiles_NewReg_userID",
                        column: x => x.userID,
                        principalTable: "NewReg",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Exec",
                columns: new[] { "execID", "bio", "execFirstName", "execGamingTag", "execHierarchy", "execLastName", "execPic", "execTitle", "favGame", "loginAmt", "username" },
                values: new object[,]
                {
                    { "001", " Oluwadamilola Gobljnn Adebayo (Dammy), a chemical engineer, one of the co-founders of ODINxGAMING goes by the gamer His favourite genre to play is FPS, which includes a shit - ton of Overwatch and Call of Duty.He also dabbles in a bit of Rocket League buthe dog water.Gobljnn is ODINxGaming's Lead Developer and UI Support member.", "Damm", "Gobljnn", "Founding", "Adebayo", null, "Programmer", "OW", null, "Gobljnn" },
                    { "002", null, "Kitan", "Kitan3000", "Founding", "Adebowale", null, "Photographer", "COD", null, "Kitan3000" },
                    { "003", null, "Nathan", "Fishboy8383", "Founding", "Stayer", null, "Community Manager", "League", null, "Fishboy8383" }
                });

            migrationBuilder.InsertData(
                table: "NewReg",
                columns: new[] { "Id", "email", "firstName", "gamerTag", "lastName", "profilePic", "role", "roleId", "userName" },
                values: new object[] { "xyz", null, "Test", null, "Admin", "../../Assets/Pic/Fishboi8383logo.jpg", null, null, null });

            migrationBuilder.InsertData(
                table: "ExecSocial",
                columns: new[] { "socialID", "discordLink", "discordName", "execId", "execName", "instaLink", "live", "logo", "scLink", "tiktokLink", "ttvlink", "twitLink" },
                values: new object[] { 1, null, null, "001", "Gobljnn", null, null, null, "soundcloud.com/gobljnn", null, "twitch.tv/gobljnn", null });

            migrationBuilder.InsertData(
                table: "ExecSocial",
                columns: new[] { "socialID", "discordLink", "discordName", "execId", "execName", "instaLink", "live", "logo", "scLink", "tiktokLink", "ttvlink", "twitLink" },
                values: new object[] { 2, null, null, "001", "K3k", null, null, null, "soundcloud.com/k3k", null, "twitch.tv/k3k", null });

            migrationBuilder.CreateIndex(
                name: "IX_ExecSocial_execId",
                table: "ExecSocial",
                column: "execId");

            migrationBuilder.CreateIndex(
                name: "IX_NewReg_roleId",
                table: "NewReg",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_userID",
                table: "UserFiles",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecSocial");

            migrationBuilder.DropTable(
                name: "UserFiles");

            migrationBuilder.DropTable(
                name: "Exec");

            migrationBuilder.DropTable(
                name: "NewReg");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
