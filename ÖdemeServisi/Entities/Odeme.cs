using System;
using System.ComponentModel.DataAnnotations;

namespace ÖdemeServisi.Entities
{
    public class Odeme
    {
        [Key]
        public int OdemeId { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public int OdemeYapanId { get; set; }
        public double OdemeMiktarı { get; set; }
        public string OdemeAcıklama { get; set; }
    }
}
