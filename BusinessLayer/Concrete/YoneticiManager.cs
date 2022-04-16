using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;


namespace BusinessLayer.Concrete
{
    public class YoneticiManager : IYoneticiService
    {
        IYoneticiDal _yoneticiDal;

        public YoneticiManager(IYoneticiDal yoneticiDal)
        {
            _yoneticiDal = yoneticiDal;
        }
        public void AddT(Yonetici t)
        {
            _yoneticiDal.Add(t);
        }

        public void DeleteT(Yonetici t)
        {
            _yoneticiDal.Delete(t);
        }

        public List<Yonetici> GetAllQuery()
        {
            return _yoneticiDal.GetAllQuery();
        }

        public Yonetici GetQueryById(int id)
        {
            return _yoneticiDal.GetQueryById(id);
        }

        public void UpdateT(Yonetici t)
        {
            _yoneticiDal.Update(t);
        }
    }
}
