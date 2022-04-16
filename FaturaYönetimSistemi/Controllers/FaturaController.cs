using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace FaturaYönetimSistemi.Controllers
{
    public class FaturaController : Controller
    {
        FaturaManager manager = new FaturaManager(new EFFaturaRepository());
        public IActionResult KullanıcıGetAllFaturas()
        {
            var faturalar = manager.GetAllQueryWithKullanıcı();
            return View(faturalar);
        }
        public IActionResult AdminGetAllFaturas()
        {
            var faturalar = manager.GetAllQueryWithKullanıcı();
            return View(faturalar);
        }
        [HttpGet]
        public IActionResult AddFatura()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFatura(Fatura fatura)
        {
            return View();
        }
    }
}
