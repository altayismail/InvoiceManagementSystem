using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaturaController : Controller
    {
        FaturaManager faturaManager = new FaturaManager(new EFFaturaRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetFatura(int page = 1)
        {
            var faturalar = faturaManager.GetAllQueryWithKullanıcı().ToPagedList(page, 10);
            return View(faturalar);
        }

        [HttpGet]
        public IActionResult AddFatura()
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
        public IActionResult AddFatura(Fatura fatura)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            FaturaValidator validator = new FaturaValidator();
            ValidationResult validationResult = validator.Validate(fatura);
            if (validationResult.IsValid)
            {
                faturaManager.AddT(fatura);
                return RedirectToAction("GetFatura");
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
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Faturalar");
                workSheet.Cell(1, 1).Value = "Fatura Id";
                workSheet.Cell(1, 2).Value = "Fatura Tarihi";
                workSheet.Cell(1, 3).Value = "Fatura Son Ödeme Tarihi";
                workSheet.Cell(1, 4).Value = "Fatura Durumu";
                workSheet.Cell(1, 5).Value = "Fatura Tipi";
                workSheet.Cell(1, 6).Value = "Fatura Sahibi";
                workSheet.Cell(1, 7).Value = "Fatura Tutarı";

                int BlogRowCount = 2;

                foreach (var item in faturaManager.GetAllQueryWithKullanıcı())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.FaturaId;
                    workSheet.Cell(BlogRowCount, 2).Value = item.FaturaTarihi.ToShortDateString();
                    workSheet.Cell(BlogRowCount, 3).Value = item.FaturaSonOdemeTarihi.ToShortDateString();
                    if (item.FaturaOdendiMi)
                        workSheet.Cell(BlogRowCount, 4).Value = "Ödendi";
                    else
                        workSheet.Cell(BlogRowCount, 4).Value = "Ödenmedi";
                    workSheet.Cell(BlogRowCount, 5).Value = item.FaturaTipi;
                    workSheet.Cell(BlogRowCount, 6).Value = item.FaturaKullanıcı.KullanıcıIsım + " " + item.FaturaKullanıcı.KullanıcıSoyisim;
                    workSheet.Cell(BlogRowCount, 7).Value = item.FaturaTutarı + " TL";
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Faturalar.xlsx");
                }
            }
        }
    }
}
