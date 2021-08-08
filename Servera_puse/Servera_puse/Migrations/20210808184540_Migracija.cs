using Microsoft.EntityFrameworkCore.Migrations;

namespace Servera_puse.Migrations
{
    public partial class Migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Extension",
                columns: table => new
                {
                    Extension_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extension", x => x.Extension_name);
                });

            migrationBuilder.CreateTable(
                name: "Parametrs",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametrs", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datnes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Descryption = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Extension_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datnes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Datnes_Extension_Extension_name",
                        column: x => x.Extension_name,
                        principalTable: "Extension",
                        principalColumn: "Extension_name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Datnes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parametrs",
                columns: new[] { "Name", "Value" },
                values: new object[,]
                {
                    { "Size", 5 },
                    { "a_max", 300 },
                    { "b_max", 300 },
                    { "a_min", 100 },
                    { "b_min", 100 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "wcIksDzZvHtqhtd/XazkAZF2bEhc1V3EjK+ayHMzXW8=", "Admin", null, "Admin" },
                    { 2, "tRLZfny/l8Jz5NsHO7tUeqZahFiSJ/jz2eSnK5Nyok0=", "User", null, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datnes_Extension_name",
                table: "Datnes",
                column: "Extension_name");

            migrationBuilder.CreateIndex(
                name: "IX_Datnes_UserId",
                table: "Datnes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datnes");

            migrationBuilder.DropTable(
                name: "Parametrs");

            migrationBuilder.DropTable(
                name: "Extension");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
