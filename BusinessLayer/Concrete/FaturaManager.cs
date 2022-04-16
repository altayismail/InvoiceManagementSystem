using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class FaturaManager : IFaturaService
    {
        IFaturaDal _faturaDal;

        public FaturaManager(IFaturaDal faturaDal)
        {
            _faturaDal = faturaDal;
        }

        public void AddT(Fatura t)
        {
            _faturaDal.Add(t);
        }

        public void DeleteT(Fatura t)
        {
            _faturaDal.Delete(t);
        }

        public List<Fatura> GetAllQuery()
        {
            return _faturaDal.GetAllQuery();
        }

        public List<Fatura> GetAllQueryWithKullanıcı()
        {
            return _faturaDal.GetQueryWithKullanıcı();
        }

        public Fatura GetQueryById(int id)
        {
            return _faturaDal.GetQueryById(id);
        }

        public void UpdateT(Fatura t)
        {
            _faturaDal.Update(t);
        }
    }
}
