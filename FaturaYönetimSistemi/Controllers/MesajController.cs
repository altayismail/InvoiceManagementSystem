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
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetSentMesaj()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var mesajlar = manager.GetAllQueryWithYoneticiAndKullanıcı(kullanıcı.KullanıcıId).Where(x => x.MesajYollayanId == kullanıcı.KullanıcıId).ToList<Mesaj>();
            return View(mesajlar);
        }
        [HttpGet]
        public IActionResult AddMesaj()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMesaj(Mesaj mesaj, int id)
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            MesajValidator validator = new MesajValidator();
            ValidationResult validationResult = validator.Validate(mesaj);
            if (validationResult.IsValid)
            {
                mesaj.MesajAlanId = id;
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
