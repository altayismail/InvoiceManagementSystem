using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IKullanıcıDal : IGenericDal<Kullanıcı>
    {
        Kullanıcı GetKullanıcıBySession(string name);

    }
}
