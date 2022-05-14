using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AidatController : Controller
    {
        AidatManager aidatManager = new AidatManager(new EFAidatRepository());
        KullanıcıManager kullanıcıManager = new(new EFKullanıcıRepository());
        public IActionResult GetAidat(int page = 1)
        {
            var aidatlar = aidatManager.GetAllQueryWithKullanıcı().ToPagedList(page,10);
            return View(aidatlar);
        }

        [HttpGet]
        public IActionResult AddAidat()
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            return View();
        }

        [HttpPost]
        public IActionResult AddAidat(Aidat aidat)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            AidatValidator validator = new AidatValidator();
            ValidationResult validationResult = validator.Validate(aidat);
            if (validationResult.IsValid)
            {
                aidatManager.AddT(aidat);
                return RedirectToAction("GetAidat", "Aidat");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult ExportStaticExcelAidatList()
        {
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Aidatlar");
                workSheet.Cell(1, 1).Value = "Aidat Id";
                workSheet.Cell(1, 2).Value = "Aidat Tarihi";
                workSheet.Cell(1, 3).Value = "Aidat Son Ödeme Tarihi";
                workSheet.Cell(1, 4).Value = "Aidat Durumu";
                workSheet.Cell(1, 5).Value = "Aidat Ücreti";
                workSheet.Cell(1, 6).Value = "Aidat Sahibi";

                int BlogRowCount = 2;

                foreach (var item in aidatManager.GetAllQueryWithKullanıcı())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.AidatId;
                    workSheet.Cell(BlogRowCount, 2).Value = item.AidatTarihi.ToShortDateString();
                    workSheet.Cell(BlogRowCount, 3).Value = item.AidatSonOdemeTarihi.ToShortDateString();
                    if (item.AidatOdendiMi)
                        workSheet.Cell(BlogRowCount, 4).Value = "Ödendi";
                    else
                        workSheet.Cell(BlogRowCount, 4).Value = "Ödenmedi";
                    workSheet.Cell(BlogRowCount, 5).Value = item.AidatUcreti + " TL";
                    workSheet.Cell(BlogRowCount, 6).Value = item.AidatKullanıcı.KullanıcıIsım + " " + item.AidatKullanıcı.KullanıcıSoyisim;
                    BlogRowCount++;
                }

                using ( var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Aidatlar.xlsx");
                }
            }
        }
        [HttpGet]
        public IActionResult AddAidatForAllUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAidatForAllUser(Aidat aidat)
        {
            AidatValidator validator = new AidatValidator();
            ValidationResult validationResult = validator.Validate(aidat);
            if (validationResult.IsValid)
            {
                Aidat tempAidat = new Aidat();
                foreach (var kullanıcı in kullanıcıManager.GetAllQuery())
                {
                    tempAidat = aidat;
                    tempAidat.AidatKullanıcıId = kullanıcı.KullanıcıId;
                    aidatManager.AddT(tempAidat);
                }
                return RedirectToAction("GetAidat", "Aidat");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
