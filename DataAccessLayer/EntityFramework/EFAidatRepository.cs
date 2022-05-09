using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EFAidatRepository : GenericRepository<Aidat>, IAidatDal
    {
        public List<Aidat> AddAidatForAllKullanıcı(Aidat aidat)
        {
            using(var context = new Context())
            {
                List<Aidat> aidatlar = new List<Aidat>();
                foreach (var kullanıcı in context.Kullanıcılar)
                {
                    aidat.AidatKullanıcıId = kullanıcı.KullanıcıId;
                    aidatlar.Add(aidat);
                }
                return aidatlar;
            };
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
