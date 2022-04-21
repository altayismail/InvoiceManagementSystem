using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Aidat
    {
        [Key]
        public int AidatId { get; set; }
        public DateTime AidatTarihi { get; set; }
        public DateTime AidatSonOdemeTarihi { get; set; }
        public double AidatUcreti { get; set; }
        public bool AidatOdendiMi { get; set; } = false;

        public int AidatKullanıcıId { get; set; }
        public Kullanıcı AidatKullanıcı { get; set; }

    }
}
