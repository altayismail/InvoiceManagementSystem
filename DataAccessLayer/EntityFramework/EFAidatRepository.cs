using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFAidatRepository : GenericRepository<Aidat>, IAidatDal
    {
        public void AddAidatForAllKullanıcı(Aidat aidat)
        {
            using(var context = new Context())
            {
                var kullanıcıList = context.Database.ExecuteSqlRaw("INSERT INTO ");
            }
        }

        public void AidatUpdateById(int id)
        {
            using(var context = new Context())
            {
                var aidat = context.Aidatlar.SingleOrDefault(x => x.AidatId == id);
                aidat.AidatOdendiMi = true;
                context.SaveChanges();
            }
        }

        public double CalculateToplamOdenmemisAidat()
        {
            using(var context = new Context())
            {
                var odenmemisAidatlar = context.Aidatlar.Where(x => x.AidatOdendiMi == false).ToList<Aidat>();
                return odenmemisAidatlar.Sum(x => x.AidatUcreti);
            };
        }

        public int GetAllOdenmemisAidatSayısı(Kullanıcı kullanıcı)
        {
            using (var context = new Context())
            {
                return context.Aidatlar.Where(x => x.AidatKullanıcıId == kullanıcı.KullanıcıId && x.AidatOdendiMi == false).ToList<Aidat>().Count();
            };
        }

        public List<Aidat> GetQueryWithKullanıcı()
        {
            using(var context = new Context())
            {
                return context.Aidatlar.Include(x => x.AidatKullanıcı).ToList();
            };
        }
    }
}
