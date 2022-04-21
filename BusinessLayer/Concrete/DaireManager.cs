using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class DaireManager : IDaireService
    {
        IDaireDal _daireDal;

        public DaireManager(IDaireDal daireDal)
        {
            _daireDal = daireDal;
        }

        public void AddT(Daire t)
        {
            _daireDal.Add(t);
        }

        public void DeleteT(Daire t)
        {
            _daireDal.Delete(t);
        }

        public List<Daire> GetAllDaireWithKullanıcı()
        {
            return _daireDal.GetAllDaireWithKullanıcı();
        }

        public List<Daire> GetAllQuery()
        {
            return _daireDal.GetAllQuery();
        }

        public Daire GetQueryById(int id)
        {
            return _daireDal.GetQueryById(id);
        }

        public void UpdateT(Daire t)
        {
            _daireDal.Update(t);
        }
    }
}
