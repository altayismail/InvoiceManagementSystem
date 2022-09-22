using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OdemeSistemi.Entities;
using System.Text;

namespace FaturaYönetimSistemi.Controllers
{
    public class OdemeController : Controller
    {
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        FaturaManager faturaManager = new(new EFFaturaRepository());
        AidatManager aidatManager = new(new EFAidatRepository());
        string baseUrl = "https://localhost:7200/";

        [HttpGet]
        public IActionResult GetOdenmemisAidat()
        {
            var aidatlar = aidatManager.GetAllQueryWithKullanıcı()
                .Where(x => x.AidatOdendiMi == false && x.AidatKullanıcıId == kullanıcıManager.GetKullanıcıBySession(User.Identity.Name).KullanıcıId)
                .ToList<Aidat>();
            ViewBag.odenmemisAidatSayısı = aidatlar.Count();
            return View(aidatlar);
        }

        [HttpGet]
        public IActionResult GetOdenmemisFatura()
        {
            var faturalar = faturaManager.GetAllQueryWithKullanıcı()
                .Where(x => x.FaturaOdendiMi == false && x.FaturaKullanıcıId == kullanıcıManager.GetKullanıcıBySession(User.Identity.Name).KullanıcıId)
                .ToList<Fatura>();
            ViewBag.odenmemisFaturaSayısı = faturalar.Count();
            return View(faturalar);
        }

        [HttpGet]
        public IActionResult AidatOdeme(int id)
        {
            var aidat = aidatManager.GetQueryById(id);
            Odeme odeme = new Odeme();
            odeme.OdemeNetTutarı = aidat.AidatUcreti;
            odeme.OdemeAidatId = id;
            return View(odeme);
        }

        [HttpPost]
        public async Task<IActionResult> AidatOdeme(Odeme odeme)
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);

            odeme.OdemeTarihi = DateTime.Now;
            odeme.OdemeYapanKullanıcıEmail = kullanıcı.KullanıcıEmail;
            odeme.OdemeYapanKullanıcıId = kullanıcı.KullanıcıId;
            odeme.OdemeYapanKullanıcıIsim = kullanıcı.KullanıcıIsım;
            odeme.OdemeYapanKullanıcıSoyisim = kullanıcı.KullanıcıSoyisim;
            odeme.OdemeYapanKullanıcıTCNo = kullanıcı.KullanıcıTCNo;
            odeme.OdemeTutarı = odeme.OdemeNetTutarı;

            var httpClient = new HttpClient();
            var jsonOdeme = JsonConvert.SerializeObject(odeme);
            StringContent stringContent = new StringContent(jsonOdeme, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(baseUrl + "api/Odeme", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                aidatManager.UpdateAidatDurumu(odeme.OdemeAidatId);
                return RedirectToAction("GetAidat","Aidat");
            }
            else
            {
                ViewBag.Message = "Ödeme gerçekleştirilirken bir hata oluştu, tekrar deneyiniz.";
            }
            return View();
        }

        [HttpGet]
        public IActionResult FaturaOdeme(int id)
        {
            var fatura = faturaManager.GetQueryById(id);
            Odeme odeme = new Odeme();
            odeme.OdemeNetTutarı = fatura.FaturaTutarı;
            odeme.OdemeFaturaId = id;
            odeme.OdemeFaturaTipi = fatura.FaturaTipi;
            return View(odeme);
        }

        [HttpPost]
        public async Task<IActionResult> FaturaOdeme(Odeme odeme)
        {
            var kullanıcı = kullanıcıManager.GetKullanıcıBySession(User.Identity.Name);

            odeme.OdemeTarihi = DateTime.Now;
            odeme.OdemeYapanKullanıcıEmail = kullanıcı.KullanıcıEmail;
            odeme.OdemeYapanKullanıcıId = kullanıcı.KullanıcıId;
            odeme.OdemeYapanKullanıcıIsim = kullanıcı.KullanıcıIsım;
            odeme.OdemeYapanKullanıcıSoyisim = kullanıcı.KullanıcıSoyisim;
            odeme.OdemeYapanKullanıcıTCNo = kullanıcı.KullanıcıTCNo;
            odeme.OdemeTutarı = odeme.OdemeNetTutarı;

            var httpClient = new HttpClient();
            var jsonOdeme = JsonConvert.SerializeObject(odeme);
            StringContent stringContent = new StringContent(jsonOdeme, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(baseUrl + "api/Odeme", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                faturaManager.UpdateFaturaById(odeme.OdemeFaturaId);
                return RedirectToAction("GetFatura","Fatura");
            }
            else
                ViewBag.Message = "Ödeme gerçekleştirilirken bir hata oluştu, tekrar deneyiniz.";
            return View();
        }
    }
}
