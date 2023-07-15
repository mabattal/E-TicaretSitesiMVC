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
    }
}