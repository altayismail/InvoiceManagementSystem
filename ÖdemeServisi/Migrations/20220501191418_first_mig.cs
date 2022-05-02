using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ÖdemeServisi.Migrations
{
    public partial class first_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankaHesapları",
                columns: table => new
                {
                    BankaHesapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaHesapNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaHesapBakiye = table.Column<double>(type: "float", nullable: false),
                    BankaHesapSahibiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankaHesapları", x => x.BankaHesapId);
                });

            migrationBuilder.CreateTable(
                name: "KrediKartları",
                columns: table => new
                {
                    KrediKartıId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KrediKartıSahibiId = table.Column<int>(type: "int", nullable: false),
                    KrediKartıNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrediKartıCV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrediKartları", x => x.KrediKartıId);
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    OdemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdemeYapanId = table.Column<int>(type: "int", nullable: false),
                    OdemeMiktarı = table.Column<double>(type: "float", nullable: false),
                    OdemeAcıklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.OdemeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankaHesapları");

            migrationBuilder.DropTable(
                name: "KrediKartları");

            migrationBuilder.DropTable(
                name: "Odemeler");
        }
    }
}
