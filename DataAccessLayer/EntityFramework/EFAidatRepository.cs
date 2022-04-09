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
        public List<Aidat> GetQueryWithKullanıcı()
        {
            using(var context = new Context())
            {
                return context.Aidatlar.Include(x => x.Kullanıcı).ToList();
            }
        }
    }
}
