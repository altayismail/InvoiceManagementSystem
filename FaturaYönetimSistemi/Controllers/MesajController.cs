using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class MesajController : Controller
    {
        MesajManager manager = new MesajManager(new EFMesajRepository());
        [HttpGet]
        public IActionResult GetAllMesaj()
        {
            int id = 1;
            var mesajlar = manager.GetAllQueryWithYoneticiAndKullanıcı(id);
            return View(mesajlar);
        }
        //[HttpPost]
        //public IActionResult AddMesaj(Mesaj mesaj)
        //{
        //    MesajValidator validator = new MesajValidator();
        //    ValidationResult validationResult = validator.Validate(mesaj);
        //    if (validationResult.IsValid)
        //    {
        //        mesaj.MesajTarihi = System.DateTime.Now;
        //        manager.AddT(mesaj);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in validationResult.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}
    }
}
