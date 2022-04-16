using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRules
{
    public class AidatValidator : AbstractValidator<Aidat>
    {
        public AidatValidator()
        {
            RuleFor(x => x.AidatId).NotEmpty().WithMessage("Id kısmı boş geçilemez").
                GreaterThan(0).WithMessage("Id sıfırdan büyük olmalıdır.");

            RuleFor(x => x.KullanıcıId).NotEmpty().WithMessage("Kullanıcı Id boş geçilemez").
                GreaterThan(0).WithMessage("Kullanıcı Id sıfırdan büyük olmalıdır.");

            RuleFor(x => x.AidatUcreti).NotEmpty().WithMessage("Aidat ücreti boş geçilemez.").
                GreaterThan(0).WithMessage("Aidat ücreti en az 0 TL olmalıdır");

            RuleFor(x => x.AidatTarihi).GreaterThan(DateTime.Today.AddDays(-10)).WithMessage("Aidat günü, 10 gün veya daha öncesine atanamaz");

            RuleFor(x => x.AidatSonOdemeTarihi).GreaterThan(x => x.AidatSonOdemeTarihi.AddDays(30)).WithMessage("Aidatın son ödeme tarihi, Aidat Tarihinden 30 gün sonrası olmalıdır");

            RuleFor(x => x.AidatOdendiMi).NotEmpty().WithMessage("Aidat durumu boş geçilemez");
        }
    }
}
