using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaturaYönetimSistemi.Controllers
{
    public class MesajController : Controller
    {
        MesajManager manager = new MesajManager(new EFMesajRepository());
        YoneticiManager yoneticiManager = new YoneticiManager(new EFYoneticiRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        [HttpGet]
        public IActionResult GetAllMesaj()
        {
            var yonetici = yoneticiManager.GetAllYoneticiBySession(User.Identity.Name);
            var mesajlar = manager.GetAllQueryWithYoneticiAndKullanıcı(yonetici.YoneticiId);
            return View(mesajlar);
        }
        public IActionResult GetSentMesaj()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var mesajlar = manager.GetAllQueryWithYoneticiAndKullanıcı(kullanıcı.KullanıcıId).ToList<Mesaj>();
            return View(mesajlar);
        }
        [HttpGet]
        public IActionResult AddMesaj()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMesaj(Mesaj mesaj)
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            MesajValidator validator = new MesajValidator();
            ValidationResult validationResult = validator.Validate(mesaj);
            if (validationResult.IsValid)
            {
                mesaj.MesajYollayanId = kullanıcı.KullanıcıId;
                mesaj.MesajTarihi = System.DateTime.Now;
                manager.AddT(mesaj);
                return RedirectToAction("AddMesaj","Mesaj");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
