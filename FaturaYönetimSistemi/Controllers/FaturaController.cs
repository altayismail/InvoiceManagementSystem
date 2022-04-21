using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FaturaYönetimSistemi.Controllers
{
    public class FaturaController : Controller
    {
        FaturaManager manager = new FaturaManager(new EFFaturaRepository());
        public IActionResult KullanıcıGetAllFaturas()
        {
            var faturalar = manager.GetAllQueryWithKullanıcı();
            return View(faturalar);
        }
        public IActionResult AdminGetAllFaturas()
        {
            var faturalar = manager.GetAllQueryWithKullanıcı();
            return View(faturalar);
        }
        [HttpGet]
        public IActionResult AddFatura()
        {
            KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
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
            FaturaValidator validator = new FaturaValidator();
            ValidationResult validationResult = validator.Validate(fatura);
            if (validationResult.IsValid)
            {
                manager.AddT(fatura);
                return RedirectToAction("AdminGetAllFaturas");
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
