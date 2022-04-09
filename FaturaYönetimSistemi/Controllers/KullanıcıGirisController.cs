using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaYönetimSistemi.Controllers
{
    public class KullanıcıGirisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
