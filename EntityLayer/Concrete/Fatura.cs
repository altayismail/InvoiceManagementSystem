using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }
        public string? FaturaTipi { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public DateTime FaturaSonOdemeTarihi { get; set; }
        public double FaturaTutarı { get; set; }
        public bool FaturaOdendiMi { get; set; }

        public int FaturaKullanıcıId { get; set; }
        public Kullanıcı FaturaKullanıcı { get; set; }
    }
}
