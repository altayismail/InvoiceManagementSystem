using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullanıcıController : Controller
    {
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());

        public IActionResult GetKullanıcı(int page = 1)
        {
            return View(kullanıcıManager.GetAllQuery().ToPagedList(page, 10));
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
                kullanıcıManager.AddT(kullanıcı);
                return RedirectToAction("GetKullanıcı");
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
            var kullanıcı = kullanıcıManager.GetQueryById(id);
            kullanıcıManager.DeleteT(kullanıcı);
            return RedirectToAction("GetKullanıcı");
        }
        [HttpGet]
        public IActionResult UpdateKullanıcı(int id)
        {
            var kullanıcı = kullanıcıManager.GetQueryById(id);
            return View(kullanıcı);
        }
        [HttpPost]
        public IActionResult UpdateKullanıcı(Kullanıcı kullanıcı)
        {
            KullanıcıValidator validator = new KullanıcıValidator();
            ValidationResult validationResult = validator.Validate(kullanıcı);
            if (validationResult.IsValid)
            {
                kullanıcıManager.UpdateT(kullanıcı);
                return RedirectToAction("GetKullanıcı");
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
