using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Aidat
    {
        [Key]
        public int Id { get; set; }

        public int KullanıcıId { get; set; }
        public Kullanıcı Kullanıcı { get; set; }

        public DateTime AidatTarihi { get; set; }
        public DateTime AidatSonOdemeTarihi { get; set; }
        public double AidatUcreti { get; set; }
        public bool AidatOdendiMi { get; set; }

    }
}
