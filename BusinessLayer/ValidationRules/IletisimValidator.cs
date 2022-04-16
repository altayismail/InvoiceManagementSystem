using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class IletisimValidator : AbstractValidator<Iletisim>
    {
        public IletisimValidator()
        {
            RuleFor(x => x.IletisimIsım).NotEmpty().WithMessage("İsim boş bırakılamaz").
                MinimumLength(2).WithMessage("İsim en az iki harften oluşmalı.").
                MaximumLength(15).WithMessage("İsim en fazla on beş harften oluşmalı.");

            RuleFor(x => x.IletisimSoyisim).NotEmpty().WithMessage("Soyisim boş bırakılamaz").
                MinimumLength(2).WithMessage("Soyisim en az iki harften oluşmalı.").
                MaximumLength(15).WithMessage("Soyisim en fazla on beş harften oluşmalı.");

            RuleFor(x => x.IletisimEmail).NotEmpty().WithMessage("Email kısmı boş bırakılamaz.").
                Matches("@").WithMessage("Email '@' sembolünü içermelidir.").
                Matches(".com").WithMessage("Email '.com' kısmını içermelidir.").
                MaximumLength(30).WithMessage("Email en fazla 30 karakterden oluşmalıdır.").
                MinimumLength(15).WithMessage("Email en az 15 karakterden oluşmalıdır.");

            RuleFor(x => x.IletisimKonu).NotEmpty().WithMessage("Konu boş bırakılamaz.");

            RuleFor(x => x.IletisimMesaj).NotEmpty().WithMessage("Mesaj kısmı boş bırakılamaz");
        }
    }
}
