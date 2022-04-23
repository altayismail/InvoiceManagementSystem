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
    public class AidatController : Controller
    {
        AidatManager manager = new(new EFAidatRepository());
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        public IActionResult KullanıcıGetAllAidats()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var aidatlar = manager.GetAllQueryWithKullanıcı().Where(x => x.AidatKullanıcıId == kullanıcı.KullanıcıId).ToList<Aidat>();
            return View(aidatlar); 
        }

        public IActionResult AdminGetAllAidats()
        {
            var aidatlar = manager.GetAllQueryWithKullanıcı();
            return View(aidatlar);
        }

        [HttpGet]
        public IActionResult AddAidat()
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
        public IActionResult AddAidat(Aidat aidat)
        {
            KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
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
                manager.AddT(aidat);
                return RedirectToAction("AdminGetAllAidats","Aidat");
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
