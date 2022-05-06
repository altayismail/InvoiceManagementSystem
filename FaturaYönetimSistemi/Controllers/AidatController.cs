using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using X.PagedList;

namespace FaturaYönetimSistemi.Controllers
{
    public class AidatController : Controller
    {
        AidatManager manager = new(new EFAidatRepository());
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        public IActionResult GetAidat(int page = 1)
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var aidatlar = manager.GetAllQueryWithKullanıcı()
                .Where(x => x.AidatKullanıcıId == kullanıcı.KullanıcıId).ToList<Aidat>().ToPagedList(page, 10);
            ViewBag.odenmemisAidatSayısı = manager.GetAllOdenmemisAidatSayısı(kullanıcı);
            return View(aidatlar); 
        }
    }
}
