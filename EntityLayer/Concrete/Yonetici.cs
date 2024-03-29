﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Yonetici
    {
        [Key]
        public int YoneticiId { get; set; }
        public string? YoneticiIsım { get; set; }
        public string? YoneticiSoyisim { get; set; }
        public string? YoneticiTelefonNo { get; set; }
        public string? YoneticiEmail { get; set; }
        public string? YoneticiSifre { get; set; }
        public virtual List<Mesaj> YoneticiMesajAl { get; set; }

    }
}
