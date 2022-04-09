using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class KullanıcıValidator : AbstractValidator<Kullanıcı>
    {
        public KullanıcıValidator()
        {
            RuleFor(x => x.KullanıcıIsım).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.").
                MinimumLength(2).WithMessage("Kullanıcı ismi en az 2 harf uzunluğunda olmaladır.").
                MaximumLength(30).WithMessage("Kullanıcı ismi maksimum 30 karakterden oluşmalı.");

            RuleFor(x => x.KullanıcıSoyisim).NotEmpty().WithMessage("Kullanıcı soyismi boş geçilemez.").
                MinimumLength(2).WithMessage("Kullanıcı soyismi en az 2 harf uzunluğunda olmaladır.").
                MaximumLength(30).WithMessage("Kullanıcı soyismi maksimum 30 karakterden oluşmalı.");

            RuleFor(x => x.KullanıcıEmail).NotEmpty().WithMessage("Kullanıcı e-maili boş geçilemez.");

            RuleFor(x => x.KullanıcıTCNo).NotEmpty().WithMessage("Kullanıcı şifresi boş geçilemez.").
                Length(11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.");

            RuleFor(x => x.DaireId).NotEmpty().WithMessage("Kullanıcının atanacağı daire numarası boş geçilemez").
                GreaterThan(0).WithMessage("Daire numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.KullanıcıTelefonNo).NotEmpty().WithMessage("Kullanıcı telefon numarası boş geçilemez").
                Length(10).WithMessage("Kullanıcı telefon numarası 10 haneli olamalıdır.");
        }
    }
}
