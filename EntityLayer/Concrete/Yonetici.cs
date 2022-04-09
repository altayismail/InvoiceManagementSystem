using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Yonetici
    {
        [Key]
        public int Id { get; set; }
        public string YoneticiIsım { get; set; }
        public string YoneticiSoyisim { get; set; }
        public string YoneticiTelefonNo { get; set; }
        public string YoneticiEmail { get; set; }
        public string YoneticiSifre { get; set; }
        public List<Mesaj> Mesajlar { get; set; }
    }
}
