using E_TicaretSitesiMVC.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context context = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var deger = context.Personels.Where(x => x.Sil == false).ToList().ToPagedList(sayfa, 8);
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

        public ActionResult PersonelGetir(int id)
        {
            var prs = context.Personels.Find(id);

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
            return View("PersonelEkle", prs);
        }

        public ActionResult PersonelSil(int id)
        {
            var p = context.Personels.Find(id);
            p.Sil = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGuncelle(Personel personel)
        {
            var p = context.Personels.Find(personel.PersonelID);
            p.PersonelAd = personel.PersonelAd;
            p.PersonelSoyad = personel.PersonelSoyad;
            p.PersonelGorsel = personel.PersonelGorsel;
            p.DepartmanID = personel.DepartmanID;
            p.Durum = personel.Durum;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}