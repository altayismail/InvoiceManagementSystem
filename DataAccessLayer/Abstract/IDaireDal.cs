using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IDaireDal : IGenericDal<Daire>
    {
        List<Daire> GetAllDaireWithKullanıcı();
    }
}
