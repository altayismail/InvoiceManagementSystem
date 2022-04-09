using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FaturaYonetim2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aidatlar_Kullanıcılar_KullanıcıId",
                table: "Aidatlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Faturalar_Kullanıcılar_KullanıcıId",
                table: "Faturalar");

            migrationBuilder.AddColumn<int>(
                name: "KullanıcıId",
                table: "Mesajlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DaireId",
                table: "Kullanıcılar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "KullanıcıId",
                table: "Faturalar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullanıcıId",
                table: "Daireler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullanıcıId1",
                table: "Daireler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KullanıcıId",
                table: "Aidatlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_KullanıcıId",
                table: "Mesajlar",
                column: "KullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_Daireler_KullanıcıId1",
                table: "Daireler",
                column: "KullanıcıId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Aidatlar_Kullanıcılar_KullanıcıId",
                table: "Aidatlar",
                column: "KullanıcıId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Daireler_Kullanıcılar_KullanıcıId1",
                table: "Daireler",
                column: "KullanıcıId1",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faturalar_Kullanıcılar_KullanıcıId",
                table: "Faturalar",
                column: "KullanıcıId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesajlar_Kullanıcılar_KullanıcıId",
                table: "Mesajlar",
                column: "KullanıcıId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aidatlar_Kullanıcılar_KullanıcıId",
                table: "Aidatlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Daireler_Kullanıcılar_KullanıcıId1",
                table: "Daireler");

            migrationBuilder.DropForeignKey(
                name: "FK_Faturalar_Kullanıcılar_KullanıcıId",
                table: "Faturalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesajlar_Kullanıcılar_KullanıcıId",
                table: "Mesajlar");

            migrationBuilder.DropIndex(
                name: "IX_Mesajlar_KullanıcıId",
                table: "Mesajlar");

            migrationBuilder.DropIndex(
                name: "IX_Daireler_KullanıcıId1",
                table: "Daireler");

            migrationBuilder.DropColumn(
                name: "KullanıcıId",
                table: "Mesajlar");

            migrationBuilder.DropColumn(
                name: "DaireId",
                table: "Kullanıcılar");

            migrationBuilder.DropColumn(
                name: "KullanıcıId",
                table: "Daireler");

            migrationBuilder.DropColumn(
                name: "KullanıcıId1",
                table: "Daireler");

            migrationBuilder.AlterColumn<int>(
                name: "KullanıcıId",
                table: "Faturalar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KullanıcıId",
                table: "Aidatlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aidatlar_Kullanıcılar_KullanıcıId",
                table: "Aidatlar",
                column: "KullanıcıId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faturalar_Kullanıcılar_KullanıcıId",
                table: "Faturalar",
                column: "KullanıcıId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
