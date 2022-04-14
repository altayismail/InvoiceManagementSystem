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

        public int KullanıcıId { get; set; }
        public Kullanıcı MesajKullanıcı { get; set; }
    }
}
