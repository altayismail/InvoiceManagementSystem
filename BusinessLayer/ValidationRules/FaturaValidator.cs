using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class FaturaValidator : AbstractValidator<Fatura>
    {
        public FaturaValidator()
        {
            RuleFor(x => x.FaturaTarihi).NotEmpty().WithMessage("Fatura tarihi boş geçilemez.");

            RuleFor(x => x.FaturaSonOdemeTarihi).NotEmpty().WithMessage("Fatura son ödeme tarihi boş geçilemez.");

            RuleFor(x => x.FaturaTipi).NotEmpty().WithMessage("Fatura tipi boş geçilemez.");

            RuleFor(x => x.FaturaTutarı).GreaterThan(0).WithMessage("Fatura tutarı sıfırdan büyük olmalıdır.")
                .NotEmpty().WithMessage("Fatura tutarı boş geçilemez.");

            RuleFor(x => x.FaturaKullanıcıId).NotEmpty().WithMessage("Kullanıcı boş geçilemez.");
        }
    }
}
