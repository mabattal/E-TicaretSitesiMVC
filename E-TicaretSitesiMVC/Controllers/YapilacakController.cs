using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context context = new Context();
        public ActionResult Index()
        {
            ViewBag.d1 = context.Caris.Where(x => x.Sil == false).Count().ToString();
            ViewBag.d2 = context.Uruns.Where(x => x.Sil == false).Count().ToString();
            ViewBag.d3 = context.Kategoris.Count().ToString();
            ViewBag.d4 = (from x in context.Caris select x.CariSehir).Distinct().Count().ToString();

            var yapilacaklar = context.Yapilacaks.Where(x => x.Durum == false).ToList();
            return View(yapilacaklar);
        }

        public ActionResult YapilacakEkle()
        {
            Yapilacak yapilacak = new Yapilacak();
            return View(yapilacak);
        }

        [HttpPost]
        public ActionResult YapilacakEkle(Yapilacak yapilacak)
        {
            yapilacak.Tarih = DateTime.Now;
            context.Yapilacaks.Add(yapilacak);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YapilacakSil(int id)
        {
            var yapilacak = context.Yapilacaks.Find(id);
            yapilacak.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}