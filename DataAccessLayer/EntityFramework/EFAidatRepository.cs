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
            using (var context = new Context())
            {
                List<Aidat> aidatlar = new List<Aidat>();
                foreach (var ids in context.Kullanıcılar)
                {
                    Aidat aidatIns = new Aidat();
                    aidatIns.AidatTarihi = aidat.AidatTarihi;
                    aidatIns.AidatKullanıcıId = ids.KullanıcıId;
                    aidatIns.AidatSonOdemeTarihi = aidat.AidatSonOdemeTarihi;
                    aidatIns.AidatUcreti = aidat.AidatUcreti;
                    aidatlar.Add(aidatIns);
                }
                context.Aidatlar.AddRange(aidatlar);
                context.SaveChanges();
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
