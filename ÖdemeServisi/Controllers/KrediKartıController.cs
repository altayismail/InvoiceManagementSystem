using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖdemeServisi.Controllers
{
    public class KrediKartıController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
