using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdemeSistemi.Migrations
{
    public partial class OdemeSistemiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankaHesapları",
                columns: table => new
                {
                    BankaHesabıId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaHesabıŞirket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaHesabıSahibiId = table.Column<int>(type: "int", nullable: false),
                    BankaHesabıSahibiIsim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaHesabıSahibiSoyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaHesabıSahibiTCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaHesabıSahibiEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaHesabıBakiye = table.Column<double>(type: "float", nullable: false),
                    BankaHesapNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankaHesapları", x => x.BankaHesabıId);
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    OdemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeTutarı = table.Column<double>(type: "float", nullable: false),
                    OdemeNetTutarı = table.Column<double>(type: "float", nullable: false),
                    OdemeParaBirimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeKartNumarası = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeKartNumarasıSonKullanımYıl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeKartNumarasıSonKullanımAy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeKrediKartıCVV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeKrediKartıUzerindekiIsim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeYapanKullanıcıId = table.Column<int>(type: "int", nullable: false),
                    OdemeYapanKullanıcıIsim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeYapanKullanıcıSoyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeYapanKullanıcıTCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeYapanKullanıcıSehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeYapanKullanıcıUlke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeYapanKullanıcıEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeYapanKullancıIpAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdemeBasariliMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.OdemeId);
                });

            migrationBuilder.CreateTable(
                name: "KrediKartları",
                columns: table => new
                {
                    KrediKartıId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KrediKartıIsmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıTürü = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıUzerindekiIsim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıCVV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıSonKullanımTarihiAy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıSonKullanımTarihiYıl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıSahibiEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıBankaHesabıId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrediKartları", x => x.KrediKartıId);
                    table.ForeignKey(
                        name: "FK_KrediKartları_BankaHesapları_KrediKartıBankaHesabıId",
                        column: x => x.KrediKartıBankaHesabıId,
                        principalTable: "BankaHesapları",
                        principalColumn: "BankaHesabıId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KrediKartları_KrediKartıBankaHesabıId",
                table: "KrediKartları",
                column: "KrediKartıBankaHesabıId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KrediKartları");

            migrationBuilder.DropTable(
                name: "Odemeler");

            migrationBuilder.DropTable(
                name: "BankaHesapları");
        }
    }
}
