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

            CreateMap<AddOdemeViewModel, Odeme>().ForMember(dest => dest.OdemeBasariliMi, conf => conf.MapFrom(src => src.OdemeBasariliMi == true));
        }
    }
}
