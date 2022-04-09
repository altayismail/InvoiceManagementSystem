using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Daire
    {
        [Key]
        public int Id { get; set; }
        public int DaireNo { get; set; }
        public string DaireBlok { get; set; }
        public bool DaireDurumu { get; set; }
        public string DaireTipi { get; set; }
        public string DaireKatı { get; set; }


        public Kullanıcı Kullanıcı { get; set; }
    }
}
