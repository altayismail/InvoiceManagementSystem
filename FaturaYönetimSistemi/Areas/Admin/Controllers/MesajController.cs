using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MesajController : Controller
    {
        MesajManager mesajManager = new MesajManager(new EFMesajRepository());
        YoneticiManager yoneticiManager = new YoneticiManager(new EFYoneticiRepository());
        public IActionResult GetMesaj(int page = 1)
        {
            var yonetici = yoneticiManager.GetAllYoneticiBySession(User.Identity.Name);
            var mesajlar = mesajManager.GetAllQueryWithYoneticiAndKullanıcı(yonetici.YoneticiId).ToPagedList(page, 4);
            return View(mesajlar);
        }
    }
}
