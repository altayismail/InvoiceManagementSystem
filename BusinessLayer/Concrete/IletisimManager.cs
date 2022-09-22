using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

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

        public void AddT(Iletisim t)
        {
            _iletisimDal.Add(t);
        }

        public void DeleteT(Iletisim t)
        {
            throw new System.NotImplementedException();
        }

        public List<Iletisim> GetAllQuery()
        {
            return _iletisimDal.GetAllQuery();
        }

        public Iletisim GetQueryById(int id)
        {
            return _iletisimDal.GetQueryById(id);
        }

        public void UpdateT(Iletisim t)
        {
            throw new System.NotImplementedException();
        }
    }
}
