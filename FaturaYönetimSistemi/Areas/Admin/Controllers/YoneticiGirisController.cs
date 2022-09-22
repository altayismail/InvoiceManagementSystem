using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YoneticiGirisController : Controller
    {
        [AllowAnonymous]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GirisYap(Yonetici yonetici)
        {
            Context context = new Context();
            var user = context.Yoneticiler.FirstOrDefault(x => x.YoneticiEmail == yonetici.YoneticiEmail
                                                            && x.YoneticiSifre == yonetici.YoneticiSifre);

            if (user is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, yonetici.YoneticiEmail)
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
            return RedirectToAction("GirisYap","YoneticiGiris");
        }
    }
}
