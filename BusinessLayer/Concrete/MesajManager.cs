using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MesajManager : IMesajService
    {
        IMesajDal _mesajDal;

        public MesajManager(IMesajDal mesajDal)
        {
            _mesajDal = mesajDal;
        }
        public void AddT(Mesaj t)
        {
            _mesajDal.Add(t);
        }

        public void DeleteT(Mesaj t)
        {
            _mesajDal.Delete(t);
        }

        public List<Mesaj> GetAllQuery()
        {
            return _mesajDal.GetAllQuery();
        }

        public List<Mesaj> GetAllQueryByKullanıcı(int id)
        {
            return _mesajDal.GetAllQuery().Where(x => x.MesajAlanId == id).ToList();
        }

        public List<Mesaj> GetAllQueryWithYoneticiAndKullanıcı(int id)
        {
            return _mesajDal.GetAllQueryWithYoneticiAndKullanıcı(id);
        }

        public Mesaj GetQueryById(int id)
        {
            return _mesajDal.GetQueryById(id);
        }

        public void UpdateT(Mesaj t)
        {
            _mesajDal.Update(t);
        }
    }
}
