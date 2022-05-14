using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AidatManager : IAidatService
    {
        IAidatDal _aidatDal;

        public AidatManager(IAidatDal aidatDal)
        {
            _aidatDal = aidatDal;
        }

        public void AddT(Aidat t)
        {
            _aidatDal.Add(t);
        }

        public void DeleteT(Aidat t)
        {
            _aidatDal.Delete(t);
        }

        public List<Aidat> GetAllQuery()
        {
            return _aidatDal.GetAllQuery();
        }

        public List<Aidat> GetAllQueryWithKullanıcı()
        {
            return _aidatDal.GetQueryWithKullanıcı();
        }

        public Aidat GetQueryById(int id)
        {
            return _aidatDal.GetQueryById(id);
        }

        public void UpdateT(Aidat t)
        {
            _aidatDal.Update(t);
        }

        public double CalculateToplamOdenmemisAidat()
        {
            return _aidatDal.CalculateToplamOdenmemisAidat();
        }

        public int GetAllOdenmemisAidatSayısı(Kullanıcı kullanıcı)
        {
            return _aidatDal.GetAllOdenmemisAidatSayısı(kullanıcı);
        }

        public void AddAidat(Aidat aidat)
        {
            _aidatDal.AddAidat(aidat);
        }
    }
}
