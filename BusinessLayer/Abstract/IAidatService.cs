using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IAidatService
    {
        void AddAidat(Aidat aidat);
        void DeleteAidat(Aidat aidat);
        void UpdateAidat(Aidat aidat);
        List<Aidat> GetAllQuery();
        Aidat GetQueryById(int id);
        List<Aidat> GetAllQueryWithKullanıcı();
    }
}
