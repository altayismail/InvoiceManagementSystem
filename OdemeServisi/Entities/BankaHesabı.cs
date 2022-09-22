using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdemeSistemi.Entities
{
    public class BankaHesabı
    {
        [Key]
        public int BankaHesabıId { get; set; }
        public string BankaHesabıŞirket { get; set; }
        public int BankaHesabıSahibiId { get; set; }
        public string BankaHesabıSahibiIsim { get; set; }
        public string BankaHesabıSahibiSoyisim { get; set; }
        public string BankaHesabıSahibiTCNo { get; set; }
        public string BankaHesabıSahibiEmail { get; set; }
        public double BankaHesabıBakiye { get; set; }
        public string BankaHesapNo { get; set; }
        public virtual List<KrediKartı> BankaHesabıKrediKartları { get; set; }
    }
}
