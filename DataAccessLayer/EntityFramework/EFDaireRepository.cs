using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFDaireRepository : GenericRepository<Daire>, IDaireDal
    {
        public List<Daire> GetAllDaireWithKullanıcı()
        {
            using(var context = new Context())
            {
                return context.Daireler.Include(x => x.DaireKullanıcı).ToList();
            }
        }
    }
}
