using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        public string? IletisimIsım { get; set; }
        public string? IletisimSoyisim { get; set; }
        public string? IletisimEmail { get; set; }
        public string? IletisimKonu { get; set; }
        public string? IletisimMesaj { get; set; }

    }
}
