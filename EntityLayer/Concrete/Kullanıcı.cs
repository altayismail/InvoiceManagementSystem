using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Kullanıcı
    {
        [Key]
        public int Id { get; set; }
        public string KullanıcıIsım { get; set; }
        public string KullanıcıSoyisim { get; set; }
        public string KullanıcıTCNo { get; set; }
        public string KullanıcıTelefonNo { get; set; }
        public string KullanıcıEmail { get; set; }
        public string KullanıcıSifre { get; set; }
        public string KullanıcıAraçBilgisi { get; set; }
        public List<Fatura> KullanıcıFaturalar { get; set; }
        public List<Aidat> KullanıcıAidatlar { get; set; }

        public int DaireId { get; set; }
        public Daire KullanıcıDaire { get; set; }
    }
}
