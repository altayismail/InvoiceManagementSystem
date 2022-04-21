using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Mesaj
    {
        [Key]
        public int MesajId { get; set; }
        public DateTime MesajTarihi { get; set; }
        public string MesajKonusu { get; set; }
        public string MesajIcerik { get; set; }
        public bool MesajOkunduMu { get; set; }

        public int? MesajAlanId { get; set; }
        public Yonetici MesajAlan { get; set; }

        public int? MesajYollayanId { get; set; }
        public Kullanıcı MesajYollayan { get; set; }
    }
}
