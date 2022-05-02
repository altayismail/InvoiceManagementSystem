using System;
using System.ComponentModel.DataAnnotations;

namespace ÖdemeServisi.Entities
{
    public class KrediKartı
    {
        [Key]
        public int KrediKartıId { get; set; }
        public int KrediKartıSahibiId { get; set; }
        public string KrediKartıNo { get; set; }
        public string KrediKartıCV { get; set; }
        public DateTime KrediKartıSonKullanımTarihi { get; set; }
    }
}
