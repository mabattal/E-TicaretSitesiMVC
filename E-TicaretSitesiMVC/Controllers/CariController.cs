using System;
using System.CodeDom;
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
        Context context = new Context();
        public ActionResult Index()
        {
            var cari = context.Caris.Where(x => x.Sil == false).ToList();

            return View(cari);
        }

        public ActionResult CariEkle()
        {
            Cari cari = new Cari();

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem{Text = "Aktif", Value="True"},
                new SelectListItem{Text = "Pasif", Value="False"}
            };
            ViewBag.Durum = durumlar;
            return View(cari);
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return CariEkle();
            }
            context.Caris.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var car = context.Caris.Find(id);
            car.Sil = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cr = context.Caris.Find(id);

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem{Text = "Aktif", Value="True"},
                new SelectListItem{Text = "Pasif", Value="False"}
            };
            ViewBag.Durum = durumlar;

            return View("CariEkle", cr);
        }

        public ActionResult CariGuncelle(Cari cari)
        {

            if (!ModelState.IsValid)
            {
                return CariGetir(cari.CariID);
            }
            var deger = context.Caris.Find(cari.CariID);
            deger.CariAd = cari.CariAd;
            deger.CariSoyad = cari.CariSoyad;
            deger.CariSehir = cari.CariSehir;
            deger.CariMail = cari.CariMail;
            deger.Durum = cari.Durum;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}