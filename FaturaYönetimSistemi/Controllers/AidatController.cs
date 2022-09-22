using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class AidatController : Controller
    {
        AidatManager aidatManager = new(new EFAidatRepository());
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        public IActionResult GetAidat()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var aidatlar = aidatManager.GetAllQueryWithKullanıcı()
                .Where(x => x.AidatKullanıcıId == kullanıcı.KullanıcıId).ToList<Aidat>();
            ViewBag.odenmemisAidatSayısı = aidatManager.GetAllOdenmemisAidatSayısı(kullanıcı);
            ViewBag.toplamAidatSayısı = aidatManager.GetAllQuery().Where(x => x.AidatKullanıcıId == kullanıcı.KullanıcıId).Count();
            return View(aidatlar); 
        }
    }
}
