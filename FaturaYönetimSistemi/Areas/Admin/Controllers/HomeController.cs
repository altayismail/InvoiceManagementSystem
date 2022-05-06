using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        YoneticiManager yoneticiManager = new YoneticiManager(new EFYoneticiRepository());
        public IActionResult Index()
        {
            var yonetici = yoneticiManager.GetAllYoneticiBySession(User.Identity.Name);
            ViewBag.yoneticiAdı = yonetici.YoneticiIsım + " " + yonetici.YoneticiSoyisim;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
