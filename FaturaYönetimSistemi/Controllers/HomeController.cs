using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        IletisimManager manager = new(new EFIletisimRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AnaSayfa()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            ViewBag.kullanıcıAdı = kullanıcı.KullanıcıIsım + " " + kullanıcı.KullanıcıSoyisim;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Iletisim iletisim)
        {
            IletisimValidator validator = new();
            ValidationResult validationResult = validator.Validate(iletisim);
            if (validationResult.IsValid)
            {
                manager.AddIletisim(iletisim);
                return RedirectToAction("Contact", "Home");
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
