using FluentValidation;
using OdemeSistemi.Application.OdemeOperation.Commands;

namespace OdemeSistemi.ValidationRules
{
    public class OdemeValidation : AbstractValidator<AddOdemeViewModel>
    {
        public OdemeValidation()
        {
            RuleFor(x => x.OdemeKartNumarası).NotEmpty().WithMessage("Lütfen kart numarasını giriniz.")
                .Length(16).WithMessage("Kart numarası 16 haneli olmalıdır.");

            RuleFor(x => x.OdemeKartNumarasıSonKullanımAy).NotEmpty().WithMessage("Kredi kartının son kullanım tarihinin ay kısmını giriniz")
                .Length(2).WithMessage("İlgili ayı, sayı olarak giriniz");

            RuleFor(x => x.OdemeKartNumarasıSonKullanımYıl).NotEmpty().WithMessage("Kredi kartının son kullanım tarihinin yıl kısmını giriniz")
                .Length(4).WithMessage("İlgili yılı, sayı olarak giriniz");

            RuleFor(x => x.OdemeKrediKartıCVV).NotEmpty().WithMessage("Kredi Kartı, CVV numarasını giriniz")
                .Length(3).WithMessage("CVV numarası 3 haneli olmalıdır.");

            RuleFor(x => x.OdemeKrediKartıUzerindekiIsim).NotEmpty().WithMessage("Kart üzerindeki isim boş bırakılamaz");

            RuleFor(x => x.OdemeNetTutarı).NotEmpty().WithMessage("Ödeme tutarı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ödeme net tutarı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.OdemeTutarı).NotEmpty().WithMessage("Odeme tutarı boş bırakılamaz")
                .GreaterThan(0).WithMessage("Ödeme tutarı sıfırdan büyük olmalıdır.");
        }
    }
}
