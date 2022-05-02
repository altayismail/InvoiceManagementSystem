using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DataAccessLayer.Abstract
{
    public interface IKullanıcıDal : IGenericDal<Kullanıcı>
    {
        Kullanıcı GetKullanıcıBySession(string name);

        List<SelectListItem> SelectListItemKullanıcı();
    }
}
