using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Daire
    {
        [Key]
        public int DaireId { get; set; }
        public int DaireNo { get; set; }
        public string DaireBlok { get; set; }
        public bool DaireDurumu { get; set; }
        public string DaireTipi { get; set; }
        public string DaireKatı { get; set; }
        public string DaireKiradaMı { get; set; }

        public int DaireKullanıcıId { get; set; }
        public Kullanıcı DaireKullanıcı { get; set; }
    }
}
