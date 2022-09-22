using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IFaturaDal : IGenericDal<Fatura>
    {
        List<Fatura> GetQueryWithKullanıcı();
        int GetAllOdenmemisFaturaSayısı(Kullanıcı kullanıcı);
        void FaturaUpdateById(int id);
    }
}
