using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OdemeSistemi.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OdemeController : Controller
    {
        string baseUrl = "https://localhost:44308/";
        public async Task<IActionResult> GetOdemeler()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(baseUrl + "api/Odeme");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var odemeler = JsonConvert.DeserializeObject<List<Odeme>>(jsonString);
            return View(odemeler);
        }
    }
}
