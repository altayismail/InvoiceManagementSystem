using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IYoneticiDal : IGenericDal<Yonetici>
    {
        List<Yonetici> GetYoneticiBySession(string name);
    }
}
