using Microsoft.EntityFrameworkCore.Migrations;

namespace ÖdemeServisi.Migrations
{
    public partial class kredikartıentity_sonkullanımtarihiproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KrediKartıSonKullanımTarihi",
                table: "KrediKartları",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KrediKartıSonKullanımTarihi",
                table: "KrediKartları");
        }
    }
}
