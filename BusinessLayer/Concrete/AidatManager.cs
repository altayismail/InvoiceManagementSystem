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

        public void AddAidat(Aidat aidat)
        {
            _aidatDal.Add(aidat);
        }

        public void DeleteAidat(Aidat aidat)
        {
            _aidatDal.Delete(aidat);
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

        public void UpdateAidat(Aidat aidat)
        {
            _aidatDal.Update(aidat);
        }
    }
}
