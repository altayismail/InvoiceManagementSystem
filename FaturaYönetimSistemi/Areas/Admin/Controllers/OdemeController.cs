using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OdemeSistemi.Application.OdemeOperation.Queries;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OdemeController : Controller
    {
        string baseUrl = "https://localhost:7200";
        public async Task<IActionResult> GetOdemeler()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(baseUrl + "/api/Odeme");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var odemeler = JsonConvert.DeserializeObject<List<GetOdemeViewModel>>(jsonString);
            return View(odemeler);
        }
    }
}
