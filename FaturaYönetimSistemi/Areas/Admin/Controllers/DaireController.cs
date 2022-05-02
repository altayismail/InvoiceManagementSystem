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
    public class DaireController : Controller
    {
        DaireManager daireManager = new DaireManager(new EFDaireRepository());
        KullanıcıManager kullanıcıManager = new KullanıcıManager(new EFKullanıcıRepository());
        public IActionResult GetDaire(int page = 1)
        {
            return View(daireManager.GetAllDaireWithKullanıcı().ToPagedList(page,10));
        }
        [HttpGet]
        public IActionResult AddDaire()
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
        public IActionResult AddDaire(Daire daire)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            DaireValidator validator = new DaireValidator();
            ValidationResult validationResult = validator.Validate(daire);
            if (validationResult.IsValid)
            {
                daireManager.AddT(daire);
                return RedirectToAction("GetDaire","Daire");
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
        public IActionResult DeleteDaire(int id)
        {
            var daire = daireManager.GetQueryById(id);
            daireManager.DeleteT(daire);
            return RedirectToAction("GetDaire","Daire");
        }

        [HttpGet]
        public IActionResult UpdateDaire(int id)
        {
            var daire = daireManager.GetQueryById(id);
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            List<SelectListItem> daireDurumu = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Dolu" , Value = true.ToString()},
                new SelectListItem() { Text = "Boş" , Value = false.ToString()}
            };
            ViewBag.daireDurumu = daireDurumu;
            return View(daire);
        }
        [HttpPost]
        public IActionResult UpdateDaire(Daire daire)
        {
            List<SelectListItem> kullanıcılar = kullanıcıManager.GetAllQuery().
                                                Select(x => new SelectListItem
                                                {
                                                    Text = x.KullanıcıIsım + " " + x.KullanıcıSoyisim,
                                                    Value = x.KullanıcıId.ToString()
                                                }).ToList();
            ViewBag.kullanıcılar = kullanıcılar;
            List<SelectListItem> daireDurumu = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Dolu" , Value = true.ToString()},
                new SelectListItem() { Text = "Boş" , Value = false.ToString()}
            };
            ViewBag.daireDurumu = daireDurumu;
            DaireValidator validator = new DaireValidator();
            ValidationResult validationResult = validator.Validate(daire);
            if (validationResult.IsValid)
            {
                daireManager.UpdateT(daire);
                return RedirectToAction("GetDaire", "Daire");
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
                var workSheet = workBook.Worksheets.Add("Daireler");
                workSheet.Cell(1, 1).Value = "Daire Id";
                workSheet.Cell(1, 2).Value = "Blok";
                workSheet.Cell(1, 3).Value = "Daire Katı";
                workSheet.Cell(1, 4).Value = "Daire Durumu";
                workSheet.Cell(1, 5).Value = "Daire No";
                workSheet.Cell(1, 6).Value = "Daire Sahibi";
                workSheet.Cell(1, 7).Value = "Daire Tipi";

                int BlogRowCount = 2;

                foreach (var item in daireManager.GetAllDaireWithKullanıcı())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.DaireId;
                    workSheet.Cell(BlogRowCount, 2).Value = item.DaireBlok;
                    workSheet.Cell(BlogRowCount, 3).Value = item.DaireKatı;
                    if (item.DaireDurumu)
                        workSheet.Cell(BlogRowCount, 4).Value = "Dolu";
                    else
                        workSheet.Cell(BlogRowCount, 4).Value = "Boş";
                    workSheet.Cell(BlogRowCount, 5).Value = item.DaireNo;
                    workSheet.Cell(BlogRowCount, 6).Value = item.DaireKullanıcı.KullanıcıIsım + " " + item.DaireKullanıcı.KullanıcıSoyisim;
                    workSheet.Cell(BlogRowCount, 7).Value = item.DaireTipi;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Daireler.xlsx");
                }
            }
        }
    }
}
