using System;
using System.ComponentModel.DataAnnotations;

namespace OdemeSistemi.Entities
{
    public class Odeme
    {
        [Key]
        public int OdemeId { get; set; }
        public double OdemeTutarı { get; set; }
        public double OdemeNetTutarı { get; set; }
        public string OdemeParaBirimi { get; set; } = "TL";
        public string OdemeKartNumarası { get; set; }
        public string OdemeKartNumarasıSonKullanımYıl { get; set; }
        public string OdemeKartNumarasıSonKullanımAy { get; set; }
        public string OdemeKrediKartıCVV { get; set; }
        public string OdemeKrediKartıUzerindekiIsim { get; set; }
        public int OdemeYapanKullanıcıId { get; set; }
        public string OdemeYapanKullanıcıIsim { get; set; }
        public string OdemeYapanKullanıcıSoyisim { get; set; }
        public string OdemeYapanKullanıcıTCNo { get; set; }
        public string OdemeYapanKullanıcıSehir { get; set; }
        public string OdemeYapanKullanıcıUlke { get; set; }
        public string OdemeYapanKullanıcıEmail { get; set; }
        public string OdemeYapanKullancıIpAdresi { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public bool OdemeBasariliMi { get; set; }
    }
}
