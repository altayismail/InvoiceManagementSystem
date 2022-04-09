using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FaturaYonetim3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FaturaOdendiMi",
                table: "Faturalar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AidatOdendiMi",
                table: "Aidatlar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaturaOdendiMi",
                table: "Faturalar");

            migrationBuilder.DropColumn(
                name: "AidatOdendiMi",
                table: "Aidatlar");
        }
    }
}
