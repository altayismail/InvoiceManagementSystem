using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AidatController : Controller
    {
        AidatManager aidatManager = new AidatManager(new EFAidatRepository());
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        public IActionResult GetAidat(int page = 1)
        {
            var aidatlar = aidatManager.GetAllQueryWithKullanıcı().ToPagedList(page,10);
            return View(aidatlar);
        }

        [HttpGet]
        public IActionResult AddAidat()
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
        public IActionResult AddAidat(Aidat aidat)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            AidatValidator validator = new AidatValidator();
            ValidationResult validationResult = validator.Validate(aidat);
            if (validationResult.IsValid)
            {
                aidatManager.AddT(aidat);
                return RedirectToAction("GetAidat", "Aidat");
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
