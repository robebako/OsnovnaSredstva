using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OsnovnaSredstva.Data.Migrations
{
    public partial class OsnSredstva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NazivGrupe",
                table: "Grupa",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OsnSredstvo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    InventurniBroj = table.Column<int>(nullable: false),
                    DatumNabave = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<double>(nullable: false),
                    NabavnaCijena = table.Column<decimal>(nullable: false),
                    GrupaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsnSredstvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsnSredstvo_Grupa_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OsnSredstvo_GrupaId",
                table: "OsnSredstvo",
                column: "GrupaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsnSredstvo");

            migrationBuilder.AlterColumn<string>(
                name: "NazivGrupe",
                table: "Grupa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
