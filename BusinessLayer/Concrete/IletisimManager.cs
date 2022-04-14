using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class IletisimManager : IIletisimService
    {
        IIletisimDal _iletisimDal;

        public IletisimManager(IIletisimDal iletisimDal)
        {
            _iletisimDal = iletisimDal;
        }
        public void AddIletisim(Iletisim iletisim)
        {
            _iletisimDal.Add(iletisim);
        }

        public List<Iletisim> GetAllQuery()
        {
            return _iletisimDal.GetAllQuery();
        }
    }
}
