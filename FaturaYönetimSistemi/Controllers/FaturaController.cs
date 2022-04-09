using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaYönetimSistemi.Controllers
{
    public class FaturaController : Controller
    {
        FaturaManager manager = new FaturaManager(new EFFaturaRepository());
        public IActionResult Index()
        {
            var faturalar = manager.GetAllQueryWithKullanıcı();
            return View(faturalar);
        }
    }
}
