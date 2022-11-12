using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FaturaYönetimSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullanıcıController : Controller
    {
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());

        public IActionResult GetKullanıcı(int page = 1)
        {
            return View(kullanıcıManager.GetAllQuery().ToPagedList(page, 10));
        }

        [HttpGet]
        public IActionResult AddKullanıcı()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddKullanıcı(Kullanıcı kullanıcı)
        {
            KullanıcıValidator validator = new();
            ValidationResult validationResult = validator.Validate(kullanıcı);
            if(kullanıcıManager.GetAllQuery().Any(x => x.KullanıcıDaireNo == kullanıcı.KullanıcıDaireNo))
            {
                ViewBag.ErrorMessage = "Bu dairede kullanıcı bulunmaktadır.";
                return View();
            }

            if (kullanıcıManager.GetAllQuery().Any(x => x.KullanıcıEmail == kullanıcı.KullanıcıEmail))
            {
                ViewBag.ErrorMessage = "Bu emaile sahip başka bir kullanıcı bulunmaktadır.";
                return View();
            }

            if (validationResult.IsValid)
            {
                kullanıcı.KullanıcıSifre = PasswordGenerator();
                kullanıcıManager.AddT(kullanıcı);
                return RedirectToAction("GetKullanıcı");
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

        public IActionResult DeleteKullanıcı(int id)
        {
            var kullanıcı = kullanıcıManager.GetQueryById(id);
            kullanıcıManager.DeleteT(kullanıcı);
            return RedirectToAction("GetKullanıcı");
        }
        [HttpGet]
        public IActionResult UpdateKullanıcı(int id)
        {
            var kullanıcı = kullanıcıManager.GetQueryById(id);
            return View(kullanıcı);
        }
        [HttpPost]
        public IActionResult UpdateKullanıcı(Kullanıcı kullanıcı)
        {
            KullanıcıValidator validator = new KullanıcıValidator();
            ValidationResult validationResult = validator.Validate(kullanıcı);
            if (kullanıcıManager.GetAllQuery().Any(x => x.KullanıcıDaireNo == kullanıcı.KullanıcıDaireNo))
            {
                ViewBag.ErrorMessage = "Bu dairede kullanıcı bulunmaktadır.";
                return View();
            }

            if (kullanıcıManager.GetAllQuery().Any(x => x.KullanıcıEmail == kullanıcı.KullanıcıEmail))
            {
                ViewBag.ErrorMessage = "Bu emaile sahip başka bir kullanıcı bulunmaktadır.";
                return View();
            }

            if (validationResult.IsValid)
            {
                kullanıcıManager.UpdateT(kullanıcı);
                return RedirectToAction("GetKullanıcı");
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

        public string PasswordGenerator()
        {
            return Guid.NewGuid().ToString("d").Substring(1, 8);
        }

        public IActionResult ExportStaticExcelAidatList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Kullanıcılar");
                workSheet.Cell(1, 1).Value = "Kullanıcı Id";
                workSheet.Cell(1, 2).Value = "Kullanıcı Ad Soyad";
                workSheet.Cell(1, 3).Value = "Kullanıcı Telefon No";
                workSheet.Cell(1, 4).Value = "Kullanıcı Email";
                workSheet.Cell(1, 5).Value = "Kullanıcı Daire No";
                workSheet.Cell(1, 6).Value = "Kullanıcı Araç Bilgisi";

                int BlogRowCount = 2;

                foreach (var item in kullanıcıManager.GetAllQuery())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.KullanıcıId;
                    workSheet.Cell(BlogRowCount, 2).Value = item.KullanıcıIsım + " " + item.KullanıcıSoyisim;
                    workSheet.Cell(BlogRowCount, 3).Value = item.KullanıcıTelefonNo;
                    workSheet.Cell(BlogRowCount, 4).Value = item.KullanıcıEmail;
                    workSheet.Cell(BlogRowCount, 5).Value = item.KullanıcıDaireNo;
                    if (item.KullanıcıAraçBilgisi is null)
                        workSheet.Cell(BlogRowCount, 6).Value = "Yok";
                    else
                        workSheet.Cell(BlogRowCount, 6).Value = item.KullanıcıAraçBilgisi;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Kullanıcılar.xlsx");
                }
            }
        }
    }
}
