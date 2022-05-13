using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaturaYönetimSistemi.Controllers
{
    public class AidatController : Controller
    {
        AidatManager manager = new(new EFAidatRepository());
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        public IActionResult GetAidat()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var aidatlar = manager.GetAllQueryWithKullanıcı()
                .Where(x => x.AidatKullanıcıId == kullanıcı.KullanıcıId).ToList<Aidat>();
            ViewBag.odenmemisAidatSayısı = manager.GetAllOdenmemisAidatSayısı(kullanıcı);
            ViewBag.toplamAidatSayısı = manager.GetAllQuery().Where(x => x.AidatKullanıcıId == kullanıcı.KullanıcıId).Count();
            return View(aidatlar); 
        }
    }
}
