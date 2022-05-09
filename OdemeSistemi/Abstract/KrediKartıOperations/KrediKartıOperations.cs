using OdemeSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdemeSistemi.Abstract.KrediKartıOperations
{
    public class KrediKartıOperations
    {
        public bool Verify_KrediKartı(List<KrediKartı> krediKartları,string KrediKartıNo, string KrediKartıÜzerindekiIsim, string CVV)
        {
            var krediKartı = krediKartları.Where(x => x.KrediKartıNo == KrediKartıNo &&
                                                        x.KrediKartıCVV == CVV &&
                                                        x.KrediKartıUzerindekiIsim == KrediKartıÜzerindekiIsim).Single();
            if (krediKartı == null)
                return true;

            return false;
        }
    }
}
