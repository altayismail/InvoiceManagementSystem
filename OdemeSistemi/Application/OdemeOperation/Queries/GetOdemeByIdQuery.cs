using AutoMapper;
using OdemeSistemi.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdemeSistemi.Application.OdemeOperation.Queries
{
    public class GetOdemeByIdQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetOdemeByIdQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int OdemeId { get; set; }

        public GetOdemeByIdViewModel Handle()
        {
            var odeme = _context.Odemeler.Where(x => x.OdemeBasariliMi == true && x.OdemeId == OdemeId).Single();

            if (odeme is null)
                throw new InvalidOperationException("Odeme bulunamadı.");

            return _mapper.Map<GetOdemeByIdViewModel>(odeme);
        }
    }

    public class GetOdemeByIdViewModel
    {
        public string OdemeYapanIsim { get; set; }
        public string OdemeYapanSoyisim { get; set; }
        public DateTime OdemeTarih { get; set; }
        public double OdemeNetTutar { get; set; }
        public string OdemeParaBirimi { get; set; }
    }
}
