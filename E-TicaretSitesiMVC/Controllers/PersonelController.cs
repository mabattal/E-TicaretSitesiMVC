using E_TicaretSitesiMVC.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context context = new Context();
        public ActionResult Index()
        {
            var deger = context.Personels.Where(x => x.Sil == false).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            Personel personel = new Personel();

            // Dropdown için seçenekleri oluşturuyoruz
            List<SelectListItem> dpt = (from x in context.Departmans.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.DepartmanAd,
                                                    Value = x.DepartmanID.ToString()
                                                }).ToList();
            // ViewBag üzerinden seçenekleri View'a gönderiyoruz
            ViewBag.Departmanlar = dpt;

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem { Text = "Aktif", Value = "true" },
                new SelectListItem { Text = "Pasif", Value = "false" }
            };

            ViewBag.Durumlar = durumlar;

            return View(personel);
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}