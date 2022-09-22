using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdemeSistemi.Migrations
{
    public partial class odeme_class_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OdemeParaBirimi",
                table: "Odemeler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OdemeAidatId",
                table: "Odemeler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OdemeFaturaId",
                table: "Odemeler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdemeAidatId",
                table: "Odemeler");

            migrationBuilder.DropColumn(
                name: "OdemeFaturaId",
                table: "Odemeler");

            migrationBuilder.AlterColumn<string>(
                name: "OdemeParaBirimi",
                table: "Odemeler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
