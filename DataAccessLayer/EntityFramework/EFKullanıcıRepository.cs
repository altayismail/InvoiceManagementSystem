using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFKullanıcıRepository : GenericRepository<Kullanıcı>, IKullanıcıDal
    {
    }
}
