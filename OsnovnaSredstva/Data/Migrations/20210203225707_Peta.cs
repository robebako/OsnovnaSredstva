using Microsoft.EntityFrameworkCore.Migrations;

namespace OsnovnaSredstva.Data.Migrations
{
    public partial class Peta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "OsnSredstvo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Kolicina",
                table: "OsnSredstvo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
