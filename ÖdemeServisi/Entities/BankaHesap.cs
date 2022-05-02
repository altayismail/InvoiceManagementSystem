using System.ComponentModel.DataAnnotations;

namespace ÖdemeServisi.Entities
{
    public class BankaHesap
    {
        [Key]
        public int BankaHesapId { get; set; }
        public string BankaHesapNo { get; set; }
        public double BankaHesapBakiye { get; set; }
        public int BankaHesapSahibiId { get; set; }

    }
}
