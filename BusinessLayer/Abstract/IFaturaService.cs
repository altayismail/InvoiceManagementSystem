using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IFaturaService
    {
        void AddFatura(Fatura fatura);
        void DeleteFatura(Fatura fatura);
        void UpdateFatura(Fatura fatura);
        List<Fatura> GetAllQuery();
        Fatura GetQueryById(int id);
        List<Fatura> GetAllQueryWithKullanıcı();
    }
}
