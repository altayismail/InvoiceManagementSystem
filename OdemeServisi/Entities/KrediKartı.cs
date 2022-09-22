using System.ComponentModel.DataAnnotations;

namespace OdemeSistemi.Entities
{
    public class KrediKartı
    {
        [Key]
        public int KrediKartıId { get; set; }
        public string? KrediKartıIsmi { get; set; }
        public string? KrediKartıTürü { get; set; }
        public string? KrediKartıUzerindekiIsim { get; set; }
        public string? KrediKartıNo { get; set; }
        public string? KrediKartıCVV { get; set; }
        public string? KrediKartıSonKullanımTarihiAy { get; set; }
        public string? KrediKartıSonKullanımTarihiYıl { get; set; }
        public string? KrediKartıSahibiEmail { get; set; }
        public int KrediKartıBankaHesabıId { get; set; }
        public BankaHesabı? KrediKartıBankaHesabı { get; set; }
    }
}
