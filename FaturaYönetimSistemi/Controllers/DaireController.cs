using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class DaireController : Controller
    {
        DaireManager manager = new DaireManager(new EFDaireRepository());
        public IActionResult GetAllDaires()
        {
            return View(manager.GetAllDaireWithKullanıcı());
        }
        [HttpGet]
        public IActionResult AddDaire()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDaire(Daire daire)
        {
            DaireValidator validator = new DaireValidator();
            ValidationResult validationResult = validator.Validate(daire);
            if (validationResult.IsValid)
            {
                daire.DaireNo = daire.DaireId;
                daire.DaireKatı = daire.DaireNo.ToString();
                manager.AddT(daire);
                return RedirectToAction("GetAllDaires");
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
            var daire = manager.GetQueryById(id);
            manager.DeleteT(daire);
            return RedirectToAction("GetAllDaires");
        }

        [HttpGet]
        public IActionResult UpdateDaire(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateDaire(Daire daire)
        {
            DaireValidator validator = new DaireValidator();
            ValidationResult validationResult = validator.Validate(daire);
            if (validationResult.IsValid)
            {
                daire.DaireNo = daire.DaireId;
                daire.DaireKatı = daire.DaireNo.ToString();
                manager.UpdateT(daire);
                return RedirectToAction("GetAllDaires");
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
