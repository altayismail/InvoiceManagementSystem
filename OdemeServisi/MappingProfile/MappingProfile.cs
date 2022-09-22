using AutoMapper;
using OdemeSistemi.Application.OdemeOperation.Commands;
using OdemeSistemi.Application.OdemeOperation.Queries;
using OdemeSistemi.Entities;

namespace OdemeSistemi.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Odeme, GetOdemeViewModel>().ForMember(dest => dest.OdemeNetTutar, conf => conf.MapFrom(src => src.OdemeNetTutarı))
                .ForMember(dest => dest.OdemeTarih, conf => conf.MapFrom(src => src.OdemeTarihi))
                .ForMember(dest => dest.OdemeYapanIsim, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıIsim))
                .ForMember(dest => dest.OdemeYapanSoyisim, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıSoyisim))
                .ForMember(dest => dest.OdemeParaBirimi, conf => conf.MapFrom(src => src.OdemeParaBirimi));

            CreateMap<Odeme, GetOdemeByIdViewModel>().ForMember(dest => dest.OdemeNetTutar, conf => conf.MapFrom(src => src.OdemeNetTutarı))
                .ForMember(dest => dest.OdemeTarih, conf => conf.MapFrom(src => src.OdemeTarihi))
                .ForMember(dest => dest.OdemeYapanIsim, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıIsim))
                .ForMember(dest => dest.OdemeYapanSoyisim, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıSoyisim))
                .ForMember(dest => dest.OdemeParaBirimi, conf => conf.MapFrom(src => src.OdemeParaBirimi));

            CreateMap<AddOdemeViewModel, Odeme>().ForMember(dest => dest.OdemeBasariliMi, conf => conf.Ignore())
                .ForMember(dest => dest.OdemeNetTutarı, conf => conf.MapFrom(src => src.OdemeNetTutarı))
                .ForMember(dest => dest.OdemeTarihi, conf => conf.MapFrom(src => src.OdemeTarihi))
                .ForMember(dest => dest.OdemeYapanKullanıcıIsim, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıIsim))
                .ForMember(dest => dest.OdemeYapanKullanıcıSoyisim, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıSoyisim))
                .ForMember(dest => dest.OdemeParaBirimi, conf => conf.MapFrom(src => src.OdemeParaBirimi))
                .ForMember(dest => dest.OdemeKartNumarası, conf => conf.MapFrom(src => src.OdemeKartNumarası))
                .ForMember(dest => dest.OdemeKartNumarasıSonKullanımAy, conf => conf.MapFrom(src => src.OdemeKartNumarasıSonKullanımAy))
                .ForMember(dest => dest.OdemeKartNumarasıSonKullanımYıl, conf => conf.MapFrom(src => src.OdemeKartNumarasıSonKullanımYıl))
                .ForMember(dest => dest.OdemeKrediKartıCVV, conf => conf.MapFrom(src => src.OdemeKrediKartıCVV))
                .ForMember(dest => dest.OdemeKrediKartıUzerindekiIsim, conf => conf.MapFrom(src => src.OdemeKrediKartıUzerindekiIsim))
                .ForMember(dest => dest.OdemeTutarı, conf => conf.MapFrom(src => src.OdemeTutarı))
                .ForMember(dest => dest.OdemeYapanKullancıIpAdresi, conf => conf.MapFrom(src => src.OdemeYapanKullancıIpAdresi))
                .ForMember(dest => dest.OdemeYapanKullanıcıEmail, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıEmail))
                .ForMember(dest => dest.OdemeYapanKullanıcıSehir, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıSehir))
                .ForMember(dest => dest.OdemeYapanKullanıcıUlke, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıUlke))
                .ForMember(dest => dest.OdemeYapanKullanıcıTCNo, conf => conf.MapFrom(src => src.OdemeYapanKullanıcıTCNo));
                
        }
    }
}
