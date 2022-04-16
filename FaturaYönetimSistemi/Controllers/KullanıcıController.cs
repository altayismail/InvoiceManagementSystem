using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FaturaYönetimSistemi.Controllers
{
    public class KullanıcıController : Controller
    {
        KullanıcıManager manager = new KullanıcıManager(new EFKullanıcıRepository());

        public IActionResult GetAllKullanıcıs()
        {
            return View(manager.GetAllQuery());
        }

        [HttpGet]
        public IActionResult AddKullanıcı()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddKullanıcı(Kullanıcı kullanıcı)
        {
            KullanıcıValidator validator = new();
            ValidationResult validationResult = validator.Validate(kullanıcı);
            if (validationResult.IsValid)
            {
                kullanıcı.KullanıcıSifre = PasswordGenerator();
                manager.AddT(kullanıcı);
                return RedirectToAction("GetAllKullanıcıs", "Kullanıcı");
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

        public IActionResult DeleteKullanıcı(int id)
        {
            var kullanıcı = manager.GetQueryById(id);
            manager.DeleteT(kullanıcı);
            return RedirectToAction("GetAllKullanıcıs");
        }
        [HttpGet]
        public IActionResult UpdateKullanıcı(int id)
        {
            var kullanıcı = manager.GetQueryById(id);
            return View(kullanıcı);
        }
        [HttpPost]
        public IActionResult UpdateKullanıcı(Kullanıcı kullanıcı)
        {
            KullanıcıValidator validator = new KullanıcıValidator();
            ValidationResult validationResult = validator.Validate(kullanıcı);
            if (validationResult.IsValid)
            {
                manager.UpdateT(kullanıcı);
                return RedirectToAction("GetAllKullanıcıs");
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
