using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IAidatDal : IGenericDal<Aidat>
    {
        List<Aidat> GetQueryWithKullanıcı();
        double CalculateToplamOdenmemisAidat();
        int GetAllOdenmemisAidatSayısı(Kullanıcı kullanıcı);
        void AddAidat(Aidat aidat);
    }
}
