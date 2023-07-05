using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cari = c.Caris.Where(x => x.Sil == false).ToList();

            return View(cari);
        }

        public ActionResult CariEkle()
        {
            Cari c = new Cari();

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem{Text = "Aktif", Value="True"},
                new SelectListItem{Text = "Pasif", Value="False"}
            };
            ViewBag.Durum = durumlar;
            return View(c);
        }

        [HttpPost]
        public ActionResult CariEkle(Cari p)
        {
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var car = c.Caris.Find(id);
            car.Sil = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cr = c.Caris.Find(id);

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem{Text = "Aktif", Value="True"},
                new SelectListItem{Text = "Pasif", Value="False"}
            };
            ViewBag.Durum = durumlar;

            return View("CariEkle", cr);
        }

        public ActionResult CariGuncelle(Cari cid)
        {
            var deger = c.Caris.Find(cid.CariID);
            deger.CariAd = cid.CariAd;
            deger.CariSoyad = cid.CariSoyad;
            deger.CariSehir = cid.CariSehir;
            deger.CariMail = cid.CariMail;
            deger.Durum = cid.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}