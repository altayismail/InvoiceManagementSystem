using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        IletisimManager manager = new(new EFIletisimRepository());
        public IActionResult KullanıcıIndex()
        {
            return View();
        }
        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult KullanıcıAbout()
        {
            return View();
        }
        public IActionResult AdminAbout()
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
