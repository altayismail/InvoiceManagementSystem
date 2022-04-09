using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFMesajRepository : GenericRepository<Mesaj>, IMesajDal
    {
    }
}
