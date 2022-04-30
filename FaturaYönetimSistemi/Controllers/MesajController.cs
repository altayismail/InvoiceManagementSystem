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
    public class MesajController : Controller
    {
        MesajManager manager = new MesajManager(new EFMesajRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        YoneticiManager yoneticiManager = new YoneticiManager(new EFYoneticiRepository());
        public IActionResult GetMesaj()
        {
            var yoneticiler = yoneticiManager.GetAllQueryWithMesaj();
            return View(yoneticiler);
        }
        public IActionResult GetMesajDetail(int id)
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var mesajlar = manager.GetAllQueryWithYoneticiAndKullanıcı(id).Where(x => x.MesajYollayanId == kullanıcı.KullanıcıId).ToList<Mesaj>();
            ViewBag.YoneticiIsim = yoneticiManager.GetQueryById(id).YoneticiIsım + " " + yoneticiManager.GetQueryById(id).YoneticiSoyisim;
            ViewBag.YoneticiTel = yoneticiManager.GetQueryById(id).YoneticiTelefonNo;
            return View(mesajlar);
        }
        [HttpGet]
        public IActionResult AddMesaj()
        {
            List<SelectListItem> yoneticiler = yoneticiManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.YoneticiIsım + " " + x.YoneticiSoyisim,
                                                    Value = x.YoneticiId.ToString()
                                                }).ToList();
            ViewBag.yoneticiler = yoneticiler;
            return View();
        }
        [HttpPost]
        public IActionResult AddMesaj(Mesaj mesaj)
        {
            List<SelectListItem> yoneticiler = yoneticiManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.YoneticiIsım + " " + x.YoneticiSoyisim,
                                                    Value = x.YoneticiId.ToString()
                                                }).ToList();
            ViewBag.yoneticiler = yoneticiler;
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            MesajValidator validator = new MesajValidator();
            ValidationResult validationResult = validator.Validate(mesaj);
            if (true)
            {
                mesaj.MesajYollayanId = kullanıcı.KullanıcıId;
                mesaj.MesajTarihi = System.DateTime.Now;
                manager.AddT(mesaj);
                return RedirectToAction("GetMesaj","Mesaj");
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
