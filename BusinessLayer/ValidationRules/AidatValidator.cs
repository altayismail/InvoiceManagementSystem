using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AidatValidator : AbstractValidator<Aidat>
    {
        public AidatValidator()
        {
            RuleFor(x => x.AidatUcreti).NotEmpty().WithMessage("Aidat ücreti boş geçilemez.").
                GreaterThan(0).WithMessage("Aidat ücreti sıfırdan büyük olmalıdır");

            RuleFor(x => x.AidatTarihi).NotEmpty().WithMessage("Aidat tarihi boş bıraklamaz.");

            RuleFor(x => x.AidatSonOdemeTarihi).NotEmpty().WithMessage("Aidat son ödeme tarihi boş bıraklamaz.");

        }
    }
}
