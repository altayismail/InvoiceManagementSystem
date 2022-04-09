using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FaturaYönetimSistemi.Controllers
{
    public class AidatController : Controller
    {
        AidatManager manager = new(new EFAidatRepository());
        public IActionResult Index()
        {
            var aidatlar = manager.GetAllQueryWithKullanıcı();
            return View(aidatlar);
        }
    }
}
