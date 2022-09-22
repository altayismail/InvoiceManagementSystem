using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class FaturaController : Controller
    {
        FaturaManager faturaManager = new FaturaManager(new EFFaturaRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetFatura()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var faturalar = faturaManager.GetAllQueryWithKullanıcı()
                .Where(x => x.FaturaKullanıcıId == kullanıcı.KullanıcıId).ToList<Fatura>();
            ViewBag.odenmemisFaturaSayısı = faturaManager.GetAllOdenmemisFaturaSayısı(kullanıcı);
            ViewBag.toplamFaturaSayısı = faturaManager.GetAllQuery().Where(x => x.FaturaKullanıcıId == kullanıcı.KullanıcıId).Count();
            return View(faturalar);
        }
    }
}
