using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖdemeServisi.Controllers
{
    public class OdemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
