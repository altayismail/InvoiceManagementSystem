using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdemeSistemi.Migrations
{
    public partial class odeme_fatura_tipi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OdemeFaturaTipi",
                table: "Odemeler",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdemeFaturaTipi",
                table: "Odemeler");
        }
    }
}
