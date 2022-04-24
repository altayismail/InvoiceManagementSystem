using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaturaController : Controller
    {
        FaturaManager faturaManager = new FaturaManager(new EFFaturaRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetFatura()
        {
            var faturalar = faturaManager.GetAllQueryWithKullanıcı();
            return View(faturalar);
        }

        [HttpGet]
        public IActionResult AddFatura()
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            return View();
        }
        [HttpPost]
        public IActionResult AddFatura(Fatura fatura)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            FaturaValidator validator = new FaturaValidator();
            ValidationResult validationResult = validator.Validate(fatura);
            if (validationResult.IsValid)
            {
                faturaManager.AddT(fatura);
                return RedirectToAction("GetFatura");
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
