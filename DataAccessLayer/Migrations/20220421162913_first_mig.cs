using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class first_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    IletisimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IletisimIsım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IletisimSoyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IletisimEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IletisimKonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IletisimMesaj = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.IletisimId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıIsım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıSoyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıTCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıTelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıSifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıAraçBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıDaireNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıId);
                });

            migrationBuilder.CreateTable(
                name: "Yoneticiler",
                columns: table => new
                {
                    YoneticiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YoneticiIsım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiSoyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiTelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoneticiSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoneticiler", x => x.YoneticiId);
                });

            migrationBuilder.CreateTable(
                name: "Aidatlar",
                columns: table => new
                {
                    AidatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AidatTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AidatSonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AidatUcreti = table.Column<double>(type: "float", nullable: false),
                    AidatOdendiMi = table.Column<bool>(type: "bit", nullable: false),
                    AidatKullanıcıId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidatlar", x => x.AidatId);
                    table.ForeignKey(
                        name: "FK_Aidatlar_Kullanıcılar_AidatKullanıcıId",
                        column: x => x.AidatKullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Daireler",
                columns: table => new
                {
                    DaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireNo = table.Column<int>(type: "int", nullable: false),
                    DaireBlok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaireDurumu = table.Column<bool>(type: "bit", nullable: false),
                    DaireTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaireKatı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaireKullanıcıId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daireler", x => x.DaireId);
                    table.ForeignKey(
                        name: "FK_Daireler_Kullanıcılar_DaireKullanıcıId",
                        column: x => x.DaireKullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faturalar",
                columns: table => new
                {
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaSonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaTutarı = table.Column<double>(type: "float", nullable: false),
                    FaturaOdendiMi = table.Column<bool>(type: "bit", nullable: false),
                    FaturaKullanıcıId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturalar", x => x.FaturaId);
                    table.ForeignKey(
                        name: "FK_Faturalar_Kullanıcılar_FaturaKullanıcıId",
                        column: x => x.FaturaKullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesajlar",
                columns: table => new
                {
                    MesajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesajTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MesajKonusu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesajIcerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MesajOkunduMu = table.Column<bool>(type: "bit", nullable: false),
                    MesajAlanId = table.Column<int>(type: "int", nullable: true),
                    MesajYollayanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlar", x => x.MesajId);
                    table.ForeignKey(
                        name: "FK_Mesajlar_Kullanıcılar_MesajYollayanId",
                        column: x => x.MesajYollayanId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mesajlar_Yoneticiler_MesajAlanId",
                        column: x => x.MesajAlanId,
                        principalTable: "Yoneticiler",
                        principalColumn: "YoneticiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aidatlar_AidatKullanıcıId",
                table: "Aidatlar",
                column: "AidatKullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_Daireler_DaireKullanıcıId",
                table: "Daireler",
                column: "DaireKullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturalar_FaturaKullanıcıId",
                table: "Faturalar",
                column: "FaturaKullanıcıId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_MesajAlanId",
                table: "Mesajlar",
                column: "MesajAlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_MesajYollayanId",
                table: "Mesajlar",
                column: "MesajYollayanId");
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
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "Mesajlar");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Yoneticiler");
        }
    }
}
