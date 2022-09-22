using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Kullanıcı
    {
        [Key]
        public int KullanıcıId { get; set; }
        public string? KullanıcıIsım { get; set; }
        public string? KullanıcıSoyisim { get; set; }
        public string? KullanıcıTCNo { get; set; }
        public string? KullanıcıTelefonNo { get; set; }
        public string? KullanıcıEmail { get; set; }
        public string? KullanıcıSifre { get; set; }
        public string? KullanıcıAraçBilgisi { get; set; }
        public List<Fatura> KullanıcıFaturalar { get; set; }
        public List<Aidat> KullanıcıAidatlar { get; set; }

        public virtual List<Mesaj> KullanıcıMesajGönder { get; set; }

        public int KullanıcıDaireNo { get; set; }
    }
}
