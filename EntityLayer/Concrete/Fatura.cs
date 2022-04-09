using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Fatura
    {
        [Key]
        public int Id { get; set; }
        public string FaturaTipi { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public DateTime FaturaSonOdemeTarihi { get; set; }
        public double FaturaTutarı { get; set; }
        public bool FaturaOdendiMi { get; set; }

        public int KullanıcıId { get; set; }
        public Kullanıcı Kullanıcı { get; set; }
    }
}
