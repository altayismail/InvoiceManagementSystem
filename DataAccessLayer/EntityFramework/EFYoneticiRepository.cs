using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFYoneticiRepository : GenericRepository<Yonetici>, IYoneticiDal
    {
    }
}
