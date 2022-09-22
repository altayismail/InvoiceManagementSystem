using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFMesajRepository : GenericRepository<Mesaj>, IMesajDal
    {
        public List<Mesaj> GetAllQueryWithYoneticiAndKullanıcı(int id)
        {
            using(var context = new Context())
            {
                return context.Mesajlar.Include(x => x.MesajAlan).Include(x => x.MesajYollayan).Where(x => x.MesajAlan.YoneticiId == id).ToList();
            }
        }
    }
}
