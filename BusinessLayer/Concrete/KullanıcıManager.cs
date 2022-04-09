using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class KullanıcıManager : IKullanıcıService
    {
        IKullanıcıDal _kullanıcıDal;
        public KullanıcıManager(IKullanıcıDal kullanıcıDal)
        {
            _kullanıcıDal = kullanıcıDal;
        }
        public void AddKullanıcı(Kullanıcı kullanıcı)
        {
            _kullanıcıDal.Add(kullanıcı);
        }
    }
}
