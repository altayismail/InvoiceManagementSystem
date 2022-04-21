using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules
{
    public class FaturaValidator : AbstractValidator<Fatura>
    {
        public FaturaValidator()
        {
            RuleFor(x => x.FaturaId).GreaterThan(0).WithMessage("Fatura Id'si, sıfırndan büyük olmalıdır");

            RuleFor(x => x.FaturaTarihi).GreaterThan(DateTime.Today.AddDays(-10)).WithMessage("Fatura günü, 10 gün veya daha öncesine atanamaz")
                .NotEmpty().WithMessage("Fatura tarihi boş geçilemez.");

            RuleFor(x => x.FaturaSonOdemeTarihi).GreaterThan(x => x.FaturaTarihi.AddMonths(1)).WithMessage("Fatura son ödeme tarihi, Aidat Tarihinden 1 ay sonrası olmalıdır")
                .NotEmpty().WithMessage("Fatura son ödeme tarihi boş geçilemez.");

            RuleFor(x => x.FaturaTipi).NotEmpty().WithMessage("Fatura tipi boş geçilemez.");

            RuleFor(x => x.FaturaTutarı).GreaterThan(0).WithMessage("Fatura tutarı sıfırdan büyük olmalıdır.")
                .NotEmpty().WithMessage("Fatura tutarı boş geçilemez.");

            RuleFor(x => x.KullanıcıId).NotEmpty().WithMessage("Kullanıcı boş geçilemez.").
                GreaterThan(0).WithMessage("Kullanıcı Id sıfırndan büyük olmalıdır.");
        }
    }
}
