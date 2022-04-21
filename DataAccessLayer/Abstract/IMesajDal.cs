using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IMesajDal : IGenericDal<Mesaj>
    {
        List<Mesaj> GetAllQueryWithYoneticiAndKullanıcı(int id);
    }
}
