using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFYoneticiRepository : GenericRepository<Yonetici>, IYoneticiDal
    {
        public List<Yonetici> GetYoneticiBySession(string name)
        {
            using(var context = new Context())
            {
                return context.Yoneticiler.Where(x => x.YoneticiEmail == name).ToList();
            }
        }
    }
}
