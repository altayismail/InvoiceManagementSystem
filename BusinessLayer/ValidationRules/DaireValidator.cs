using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class DaireValidator : AbstractValidator<Daire>
    {
        public DaireValidator()
        {
            RuleFor(x => x.DaireBlok).NotEmpty().WithMessage("Daire blok bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireDurumu).NotEmpty().WithMessage("Daire durum bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireKatı).NotEmpty().WithMessage("Daire kart bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireKullanıcıId).GreaterThan(0).WithMessage("Kullanıcı Id sıfırdan büyük olamlıdır.");

            RuleFor(x => x.DaireNo).NotEmpty().WithMessage("Daire No bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireTipi).NotEmpty().WithMessage("Daire Tipi bilgisi boş bırakılamaz.");
        }
    }
}
