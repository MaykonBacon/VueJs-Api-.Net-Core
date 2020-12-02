using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Api.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Locadoras_LocadoraId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_LocadoraId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "LocadoraId",
                table: "Filmes");

            migrationBuilder.CreateTable(
                name: "FilmeLocadoras",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    LocadoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeLocadoras", x => new { x.LocadoraId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_FilmeLocadoras_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeLocadoras_Locadoras_LocadoraId",
                        column: x => x.LocadoraId,
                        principalTable: "Locadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocadoras_FilmeId",
                table: "FilmeLocadoras",
                column: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeLocadoras");

            migrationBuilder.AddColumn<int>(
                name: "LocadoraId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_LocadoraId",
                table: "Filmes",
                column: "LocadoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Locadoras_LocadoraId",
                table: "Filmes",
                column: "LocadoraId",
                principalTable: "Locadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
