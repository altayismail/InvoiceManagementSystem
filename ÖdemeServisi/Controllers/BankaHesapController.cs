using Microsoft.AspNetCore.Mvc;
using ÖdemeServisi.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖdemeServisi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankaHesapController : Controller
    {
        private readonly Context _context;

        public BankaHesapController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBankaHesabı()
        {
            using Context con = new Context();
            var hesaplar = con.BankaHesapları.ToList();
            return Ok(hesaplar);
        }
    }
}
