using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EFFaturaRepository : GenericRepository<Fatura>, IFaturaDal
    {
        public List<Fatura> GetQueryWithKullanıcı()
        {
            using(var context = new Context())
            {
                return context.Faturalar.Include(x => x.FaturaKullanıcı).ToList();
            }
        }
    }
}
