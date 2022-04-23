using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using System.Linq;

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
    }
}
