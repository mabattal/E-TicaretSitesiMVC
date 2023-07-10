using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
    }
}