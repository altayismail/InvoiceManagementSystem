using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaturaYönetimSistemi.Controllers
{
    public class FaturaController : Controller
    {
        FaturaManager manager = new FaturaManager(new EFFaturaRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetFatura()
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            var faturalar = manager.GetAllQueryWithKullanıcı()
                .Where(x => x.FaturaKullanıcıId == kullanıcı.KullanıcıId).ToList<Fatura>();
            return View(faturalar);
        }
    }
}
