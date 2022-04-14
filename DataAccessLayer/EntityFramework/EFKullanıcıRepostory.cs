using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace FaturaYönetimSistemi.Controllers
{
    public class EFKullanıcıRepostory : GenericRepository<Kullanıcı>, IKullanıcıDal
    {

    }
}