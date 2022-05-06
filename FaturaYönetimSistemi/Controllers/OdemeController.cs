using Microsoft.AspNetCore.Mvc;
using OdemeSistemi.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaturaYönetimSistemi.Controllers
{
    public class OdemeController : Controller
    {
        [HttpGet]
        public IActionResult AddOdeme()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOdeme(Odeme odeme)
        {
            var httpClient = new HttpClient();
            return View();
        }
    }
}
