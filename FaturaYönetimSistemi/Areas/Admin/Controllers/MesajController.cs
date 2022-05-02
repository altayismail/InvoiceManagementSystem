using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MesajController : Controller
    {
        MesajManager mesajManager = new MesajManager(new EFMesajRepository());
        YoneticiManager yoneticiManager = new YoneticiManager(new EFYoneticiRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetMesaj(int id)
        {
            var yonetici = yoneticiManager.GetAllYoneticiBySession(User.Identity.Name);
            var mesajlar = mesajManager.GetAllQueryWithYoneticiAndKullanıcı(id).Where(x => x.MesajYollayanId == id).ToList<Mesaj>();
            ViewBag.KullanıcıIsim = kullanıcıManager.GetQueryById(id).KullanıcıIsım + " " + kullanıcıManager.GetQueryById(id).KullanıcıSoyisim;
            ViewBag.KullanıcıTel = kullanıcıManager.GetQueryById(id).KullanıcıTelefonNo;
            return View(mesajlar);
        }

        public IActionResult GetKullanıcılar()
        {
            var kullanıcılar = kullanıcıManager.GetAllQuery().Where(x => x.KullanıcıSoyisim != "Yok").ToList<Kullanıcı>();
            return View(kullanıcılar);
        }
    }
}
