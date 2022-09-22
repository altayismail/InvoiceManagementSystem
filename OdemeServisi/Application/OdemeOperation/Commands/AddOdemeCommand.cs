using AutoMapper;
using OdemeSistemi.Concrete;
using OdemeSistemi.Entities;

namespace OdemeSistemi.Application.OdemeOperation.Commands
{
    public class AddOdemeCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public AddOdemeViewModel? Model { get; set; }
        public AddOdemeCommand(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var krediKartı = _context.KrediKartları.Where(x => x.KrediKartıNo == Model.OdemeKartNumarası &&
                                                                x.KrediKartıCVV == Model.OdemeKrediKartıCVV &&
                                                                x.KrediKartıSonKullanımTarihiAy == Model.OdemeKartNumarasıSonKullanımAy &&
                                                                x.KrediKartıSonKullanımTarihiYıl == Model.OdemeKartNumarasıSonKullanımYıl).Single();

            if (krediKartı == null)
                throw new InvalidOperationException("Girdiğiniz kart bilgileri hatalı.");

            var bankaHesabı = _context.BankaHesapları.Where(x => x.BankaHesabıId == krediKartı.KrediKartıBankaHesabıId)
                                                .Single();

            if (bankaHesabı.BankaHesabıBakiye < Model.OdemeNetTutarı)
                throw new InvalidOperationException("Bakiyeniz yetersiz");

            bankaHesabı.BankaHesabıBakiye -= Model.OdemeNetTutarı;

            var odeme = _mapper.Map<Odeme>(Model);
            odeme.OdemeBasariliMi = true;
            _context.Odemeler.Add(odeme);
            _context.SaveChanges();
        }
    }


    public class AddOdemeViewModel
    {
        public double OdemeTutarı { get; set; }
        public double OdemeNetTutarı { get; set; }
        public string OdemeParaBirimi { get; set; } = "TL";
        public string? OdemeKartNumarası { get; set; }
        public string? OdemeKartNumarasıSonKullanımYıl { get; set; }
        public string? OdemeKartNumarasıSonKullanımAy { get; set; }
        public string? OdemeKrediKartıCVV { get; set; }
        public string? OdemeKrediKartıUzerindekiIsim { get; set; }
        public int OdemeYapanKullanıcıId { get; set; }
        public string? OdemeYapanKullanıcıIsim { get; set; }
        public string? OdemeYapanKullanıcıSoyisim { get; set; }
        public string? OdemeYapanKullanıcıTCNo { get; set; }
        public string? OdemeYapanKullanıcıSehir { get; set; }
        public string? OdemeYapanKullanıcıUlke { get; set; }
        public string? OdemeYapanKullanıcıEmail { get; set; }
        public string? OdemeYapanKullancıIpAdresi { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public bool OdemeBasariliMi { get; set; }
    }
}
