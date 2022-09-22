using AutoMapper;
using OdemeSistemi.Concrete;
using OdemeSistemi.Entities;

namespace OdemeSistemi.Application.OdemeOperation.Queries
{
    public class GetOdemeQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetOdemeQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetOdemeViewModel> Handle()
        {
            var odemeler = _context.Odemeler.Where(x => x.OdemeBasariliMi == true).ToList<Odeme>();

            if (!odemeler.Any())
                throw new InvalidOperationException("Herhangi bir ödeme bulunamadı.");

            return _mapper.Map<List<GetOdemeViewModel>>(odemeler);
        }
    }

    public class GetOdemeViewModel
    {
        public string? OdemeYapanIsim { get; set; }
        public string? OdemeYapanSoyisim { get; set; }
        public DateTime OdemeTarih { get; set; }
        public double OdemeNetTutar { get; set; }
        public string? OdemeParaBirimi { get; set; }
    }
}
