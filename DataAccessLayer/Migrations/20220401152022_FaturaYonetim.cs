using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class FaturaYonetim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Daireler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireNo = table.Column<int>(type: "int", nullable: false),
                    DaireBlok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaireDurumu = table.Column<bool>(type: "bit", nullable: false),
                    DaireTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaireKatı = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daireler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıIsım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıSoyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıTCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıTelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıSifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıAraçBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yoneticiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YoneticiIsım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiSoyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiTelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoneticiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aidatlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AidatTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AidatSonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AidatUcreti = table.Column<double>(type: "float", nullable: false),
                    KullanıcıId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidatlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aidatlar_Kullanıcılar_KullanıcıId",
                        column: x => x.KullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faturalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaSonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaTutarı = table.Column<double>(type: "float", nullable: false),
                    KullanıcıId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faturalar_Kullanıcılar_KullanıcıId",
                        column: x => x.KullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mesajlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesajTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MesajKonusu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesajIcerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesajlar_Yoneticiler_YoneticiId",
                        column: x => x.YoneticiId,
                        principalTable: "Yoneticiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aidatlar_KullanıcıId",
                table: "Aidatlar",
                column: "KullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturalar_KullanıcıId",
                table: "Faturalar",
                column: "KullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_YoneticiId",
                table: "Mesajlar",
                column: "YoneticiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aidatlar");

            migrationBuilder.DropTable(
                name: "Daireler");

            migrationBuilder.DropTable(
                name: "Faturalar");

            migrationBuilder.DropTable(
                name: "Mesajlar");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Yoneticiler");
        }
    }
}
