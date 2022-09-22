using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IAidatDal : IGenericDal<Aidat>
    {
        List<Aidat> GetQueryWithKullanıcı();
        double CalculateToplamOdenmemisAidat();
        int GetAllOdenmemisAidatSayısı(Kullanıcı kullanıcı);
        void AddAidatForAllKullanıcı(Aidat aidat);
        void AidatUpdateById(int id);
    }
}
