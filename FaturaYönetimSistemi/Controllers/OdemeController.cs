using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OdemeSistemi.Entities;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYönetimSistemi.Controllers
{
    public class OdemeController : Controller
    {
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        FaturaManager faturaManager = new(new EFFaturaRepository());
        AidatManager aidatManager = new(new EFAidatRepository());
        string baseUrl = "https://localhost:44308/";
        public IActionResult GetOdenmemisAidat()
        {
            var aidatlar = aidatManager.GetAllQueryWithKullanıcı()
                .Where(x => x.AidatOdendiMi == false && x.AidatKullanıcıId == kullanıcıManager.GetKullanıcıBySession(User.Identity.Name).KullanıcıId)
                .ToList<Aidat>();
            ViewBag.odenmemisAidatSayısı = aidatlar.Count();
            return View(aidatlar);
        }
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
            TempData["AidatUcreti"] = aidat.AidatUcreti;
            TempData["AidatId"] = aidat.AidatId;
            return View();
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
            odeme.OdemeNetTutarı = (double)TempData["AidatUcreti"];
            var httpClient = new HttpClient();
            var jsonOdeme = JsonConvert.SerializeObject(odeme);
            StringContent stringContent = new StringContent(jsonOdeme, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(baseUrl + "api/Odeme", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                aidatManager.GetQueryById((int)TempData["AidatId"]).AidatOdendiMi = true;
                ViewBag.Message = "Ödeme başarılı bir şekilde gerçekleştirildi.";
                return RedirectToPage("AidatOdeme","Odeme");
            }
            else
                ViewBag.Message = "Ödeme gerçekleştirilirken bir hata oluştu, tekrar deneyiniz.";
            return View();
        }

        [HttpGet]
        public IActionResult FaturaOdeme(int id)
        {
            var fatura = faturaManager.GetQueryById(id);
            TempData["FaturaId"] = fatura.FaturaId;
            TempData["FaturaUcreti"] = fatura.FaturaTutarı;
            TempData["FaturaTipi"] = fatura.FaturaTipi;
            return View();
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
            odeme.OdemeNetTutarı = (double)TempData["FaturaUcreti"];
            var httpClient = new HttpClient();
            var jsonOdeme = JsonConvert.SerializeObject(odeme);
            StringContent stringContent = new StringContent(jsonOdeme, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(baseUrl + "api/Odeme", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                faturaManager.GetQueryById((int)TempData["FaturaId"]).FaturaOdendiMi = true;
                ViewBag.Message = "Ödeme başarılı bir şekilde gerçekleştirildi.";
                return RedirectToPage("FaturaOdeme","Odeme");
            }
            else
                ViewBag.Message = "Ödeme gerçekleştirilirken bir hata oluştu, tekrar deneyiniz.";
            return View();
        }
    }
}
