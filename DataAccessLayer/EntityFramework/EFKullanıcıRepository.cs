using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DataAccessLayer.EntityFramework
{
    public class EFKullanıcıRepository : GenericRepository<Kullanıcı>, IKullanıcıDal
    {
        public Kullanıcı GetKullanıcıBySession(string name)
        {
            using(var context = new Context())
            {
                return context.Kullanıcılar.Where(x => x.KullanıcıEmail == name).Single();
            }
        }

        public List<SelectListItem> SelectListItemKullanıcı()
        {
            using (var context = new Context())
            {
                return context.Kullanıcılar.Select(x => new SelectListItem
                {
                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                    Value = x.KullanıcıId.ToString()
                }).ToList();
            }
        }
    }
}
