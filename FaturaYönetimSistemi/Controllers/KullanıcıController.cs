using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FaturaYönetimSistemi.Controllers
{
    public class KullanıcıController : Controller
    {
        KullanıcıManager manager = new KullanıcıManager(new EFKullanıcıRepostory());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Kullanıcı kullanıcı)
        {
            KullanıcıValidator validator = new();
            ValidationResult validationResult = validator.Validate(kullanıcı);
            if (validationResult.IsValid)
            {
                kullanıcı.KullanıcıSifre = PasswordGenerator();
                manager.AddKullanıcı(kullanıcı);
                return RedirectToAction("Index", "Kullanıcı");
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

        public string PasswordGenerator()
        {
            return Guid.NewGuid().ToString("d").Substring(1, 8);
        }
    }
}
