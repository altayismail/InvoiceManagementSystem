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

            RuleFor(x => x.KullanıcıEmail).NotEmpty().WithMessage("Email kısmı boş bırakılamaz.").
                Matches("@").WithMessage("Email '@' sembolünü içermelidir.").
                Matches(".com").WithMessage("Email '.com' kısmını içermelidir.").
                MaximumLength(30).WithMessage("Email en fazla 30 karakterden oluşmalıdır.").
                MinimumLength(15).WithMessage("Email en az 15 karakterden oluşmalıdır.");

            RuleFor(x => x.KullanıcıTCNo).NotEmpty().WithMessage("Kullanıcı şifresi boş geçilemez.").
                Length(11).WithMessage("TC kimlik numarası 11 haneli olmalıdır.").
                Matches("[0-9]").WithMessage("TC kimlik numarası sadece rakamlardan oluşmalı.");

            RuleFor(x => x.KullanıcıDaireNo).NotEmpty().WithMessage("Kullanıcının atanacağı daire numarası boş geçilemez").
                GreaterThan(0).WithMessage("Daire numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.KullanıcıTelefonNo).NotEmpty().WithMessage("Kullanıcı telefon numarası boş geçilemez").
                Length(10).WithMessage("Kullanıcı telefon numarası 10 haneli olamalıdır.").
                Matches("[0-9]").WithMessage("Telefon numarası sadece rakamlardan oluşmalı.");
        }
    }
}
