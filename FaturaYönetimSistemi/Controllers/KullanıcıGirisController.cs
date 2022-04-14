using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FaturaYönetimSistemi.Controllers
{
    public class KullanıcıGirisController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Kullanıcı kullanıcı)
        {
            Context context = new Context();
            var user = context.Kullanıcılar.FirstOrDefault(x => x.KullanıcıEmail == kullanıcı.KullanıcıEmail
                                                            && x.KullanıcıSifre == kullanıcı.KullanıcıSifre);

            if(user is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, kullanıcı.KullanıcıEmail)
                };
                var userIndetity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIndetity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "KullanıcıGiris");
            }
            else
            {
                return View();
            }
        }
    }
}
