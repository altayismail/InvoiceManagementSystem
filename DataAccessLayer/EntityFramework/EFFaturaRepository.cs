using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFFaturaRepository : GenericRepository<Fatura>, IFaturaDal
    {
        public void FaturaUpdateById(int id)
        {
            using(var context = new Context())
            {
                var fatura = context.Faturalar.SingleOrDefault(x => x.FaturaId == id);
                fatura.FaturaOdendiMi = true;
                context.SaveChanges();
            }
        }

        public int GetAllOdenmemisFaturaSayısı(Kullanıcı kullanıcı)
        {
            using(var context = new Context())
            {
                return context.Faturalar.Where(x => x.FaturaKullanıcıId == kullanıcı.KullanıcıId && x.FaturaOdendiMi == false).Count();
            }
        }

        public List<Fatura> GetQueryWithKullanıcı()
        {
            using(var context = new Context())
            {
                return context.Faturalar.Include(x => x.FaturaKullanıcı).ToList();
            }
        }
    }
}
