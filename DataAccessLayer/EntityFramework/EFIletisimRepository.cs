using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFIletisimRepository : GenericRepository<Iletisim>, IIletisimDal
    {
    }
}
