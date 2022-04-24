using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MesajController : Controller
    {
        MesajManager mesajManager = new MesajManager(new EFMesajRepository());
        YoneticiManager yoneticiManager = new YoneticiManager(new EFYoneticiRepository());
        public IActionResult GetMesaj()
        {
            var yonetici = yoneticiManager.GetAllYoneticiBySession(User.Identity.Name);
            var mesajlar = mesajManager.GetAllQueryWithYoneticiAndKullanıcı(yonetici.YoneticiId);
            return View(mesajlar);
        }
    }
}
