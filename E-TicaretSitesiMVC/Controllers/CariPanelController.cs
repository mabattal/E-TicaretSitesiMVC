using E_TicaretSitesiMVC.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var cari = context.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.adsoy = cari.CariAd + " " + cari.CariSoyad;
            return View(cari);
        }

        public ActionResult Profil()
        {
            var mail = (string)Session["CariMail"];
            var cari = context.Caris.FirstOrDefault(x => x.CariMail == mail);
            return View(cari);
        }

        public ActionResult ProfilGuncelle(Cari cari)
        {
            //sessionla gelen maili yakaladık
            var mail = (string)Session["CariMail"];
            //maile ait cariyi bulduk
            var deger = context.Caris.FirstOrDefault(x => x.CariMail == mail);
           
            deger.CariAd = cari.CariAd;
            deger.CariSoyad = cari.CariSoyad;
            deger.CariSehir = cari.CariSehir;
            deger.Sifre = cari.Sifre;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}