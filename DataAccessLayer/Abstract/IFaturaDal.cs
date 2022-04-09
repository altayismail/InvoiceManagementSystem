using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IFaturaDal : IGenericDal<Fatura>
    {
        List<Fatura> GetQueryWithKullanıcı();
    }
}
