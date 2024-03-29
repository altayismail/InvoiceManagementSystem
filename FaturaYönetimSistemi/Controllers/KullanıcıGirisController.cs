﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FaturaYönetimSistemi.Controllers
{
    [AllowAnonymous]
    public class KullanıcıGirisController : Controller
    {
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GirisYap(Kullanıcı kullanıcı)
        {
            Context context = new Context();
            var user = context.Kullanıcılar.FirstOrDefault(x => x.KullanıcıEmail == kullanıcı.KullanıcıEmail
                                                            && x.KullanıcıSifre == kullanıcı.KullanıcıSifre);

            if (user is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, kullanıcı.KullanıcıEmail)
                };
                var userIndetity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIndetity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("AnaSayfa", "Home");
            }
            else
            {
                ViewBag.Message = "Hatalı giriş bilgileri, lütfen tekrar deneyiniz.";
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
