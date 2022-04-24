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
    public class DaireController : Controller
    {
        DaireManager daireManager = new DaireManager(new EFDaireRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetDaire(int page = 1)
        {
            return View(daireManager.GetAllDaireWithKullanıcı().ToPagedList(page,10));
        }
        [HttpGet]
        public IActionResult AddDaire()
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
        public IActionResult AddDaire(Daire daire)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            DaireValidator validator = new DaireValidator();
            ValidationResult validationResult = validator.Validate(daire);
            if (validationResult.IsValid)
            {
                daireManager.AddT(daire);
                return RedirectToAction("GetDaire","Daire");
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
        public IActionResult DeleteDaire(int id)
        {
            var daire = daireManager.GetQueryById(id);
            daireManager.DeleteT(daire);
            return RedirectToAction("GetDaire","Daire");
        }

        [HttpGet]
        public IActionResult UpdateDaire(int id)
        {
            var daire = daireManager.GetQueryById(id);
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            return View(daire);
        }
        [HttpPost]
        public IActionResult UpdateDaire(Daire daire)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            DaireValidator validator = new DaireValidator();
            ValidationResult validationResult = validator.Validate(daire);
            if (validationResult.IsValid)
            {
                daireManager.UpdateT(daire);
                return RedirectToAction("GetDaire", "Daire");
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
