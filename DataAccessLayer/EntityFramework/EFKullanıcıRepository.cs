using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EFKullanıcıRepository : GenericRepository<Kullanıcı>, IKullanıcıDal
    {
    }
}
