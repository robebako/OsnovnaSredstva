using Microsoft.EntityFrameworkCore.Migrations;

namespace OsnovnaSredstva.Data.Migrations
{
    public partial class Cetvrta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OsnSredstvo_InventurniBroj",
                table: "OsnSredstvo",
                column: "InventurniBroj",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OsnSredstvo_InventurniBroj",
                table: "OsnSredstvo");
        }
    }
}
