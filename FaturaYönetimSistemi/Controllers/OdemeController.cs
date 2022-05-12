using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OdemeSistemi.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYönetimSistemi.Controllers
{
    public class OdemeController : Controller
    {
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        string baseUrl = "https://localhost:44308/";
        [HttpGet]
        public IActionResult AddOdeme()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOdeme(Odeme odeme)
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);
            odeme.OdemeTarihi = DateTime.Now;
            odeme.OdemeYapanKullanıcıEmail = kullanıcı.KullanıcıEmail;
            odeme.OdemeYapanKullanıcıId = kullanıcı.KullanıcıId;
            odeme.OdemeYapanKullanıcıIsim = kullanıcı.KullanıcıIsım;
            odeme.OdemeYapanKullanıcıSoyisim = kullanıcı.KullanıcıSoyisim;
            odeme.OdemeYapanKullanıcıTCNo = kullanıcı.KullanıcıTCNo;
            var httpClient = new HttpClient();
            var jsonOdeme = JsonConvert.SerializeObject(odeme);
            StringContent stringContent = new StringContent(jsonOdeme, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(baseUrl + "api/Odeme", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.Message = "Ödeme başarılı bir şekilde gerçekleştirildi.";
                return RedirectToPage("AddOdeme");
            }
            else
                ViewBag.Message = "Ödeme gerçekleştirilirken bir hata oluştu, tekrar deneyiniz.";
            return View();
        }
    }
}
