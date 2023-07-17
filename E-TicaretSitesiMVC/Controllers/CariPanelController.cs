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
            ViewBag.adsoy = cari.CariAd + " " + cari.CariSoyad;
            return View(cari);
        }

        public ActionResult ProfilGuncelle(Cari cari)
        {
            //sessionla gelen maili yakaladık
            var mail = (string)Session["CariMail"];
            //maile ait cariyi bulduk
            var deger = context.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.adsoy = cari.CariAd + " " + cari.CariSoyad;

            deger.CariAd = cari.CariAd;
            deger.CariSoyad = cari.CariSoyad;
            deger.CariSehir = cari.CariSehir;
            deger.Sifre = cari.Sifre;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            //sisteme giriş yapan mailinin ait olduğu kaydın id'sini yakaladık.
            var id = context.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var cari = context.Caris.FirstOrDefault(x => x.CariMail == mail);

            var degerler = context.SatisHarekets.Where(x => x.CariID == id).ToList();

            ViewBag.adsoy = cari.CariAd + " " + cari.CariSoyad;

            return View(degerler);
        }
    }
}