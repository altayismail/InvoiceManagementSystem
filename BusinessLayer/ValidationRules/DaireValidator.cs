using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class DaireValidator : AbstractValidator<Daire>
    {
        public DaireValidator()
        {
            RuleFor(x => x.DaireBlok).NotEmpty().WithMessage("Daire blok bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireDurumu).NotNull().WithMessage("Daire durum bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireKatı).NotEmpty().WithMessage("Daire kat bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireNo).NotEmpty().WithMessage("Daire No bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Daire No sıfırdan büyük olmalıdır.");

            RuleFor(x => x.DaireTipi).NotEmpty().WithMessage("Daire Tipi bilgisi boş bırakılamaz.");

            RuleFor(x => x.DaireKiradaMı).NotNull().WithMessage("Dairenin kirada olup olmadığı belirtilmelidir.");
        }
    }
}
