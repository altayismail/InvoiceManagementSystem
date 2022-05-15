using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class MesajValidator : AbstractValidator<Mesaj>
    {
        public MesajValidator()
        {
            RuleFor(x => x.MesajIcerik).NotEmpty().WithMessage("Boş mesaj gönderilemez.").
                Length(1, 100).WithMessage("Mesaj 1 ile 100 karakter uzunluğunda olmaladır.");
        }
    }
}
