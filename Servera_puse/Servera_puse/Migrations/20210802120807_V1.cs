using Microsoft.EntityFrameworkCore.Migrations;

namespace Servera_puse.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datnes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datnes_nosaukums = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datnes_konteinera_nosaukums = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Komentari = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datnes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datnes");
        }
    }
}
