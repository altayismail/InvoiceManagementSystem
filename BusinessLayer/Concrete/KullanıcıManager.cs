﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class KullanıcıManager : IKullanıcıService
    {
        IKullanıcıDal _kullanıcıDal;
        public KullanıcıManager(IKullanıcıDal kullanıcıDal)
        {
            _kullanıcıDal = kullanıcıDal;
        }

        public void AddT(Kullanıcı t)
        {
            _kullanıcıDal.Add(t);
        }

        public void DeleteT(Kullanıcı t)
        {
            _kullanıcıDal.Delete(t);
        }

        public Kullanıcı GetKullanıcıBySession(string name)
        {
            return _kullanıcıDal.GetKullanıcıBySession(name);
        }

        public List<Kullanıcı> GetAllQuery()
        {
            return _kullanıcıDal.GetAllQuery();
        }

        public Kullanıcı GetQueryById(int id)
        {
            return _kullanıcıDal.GetQueryById(id);
        }

        public void UpdateT(Kullanıcı t)
        {
            _kullanıcıDal.Update(t);
        }
    }
}
