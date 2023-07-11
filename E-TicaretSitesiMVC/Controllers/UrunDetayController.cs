using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context context = new Context();
        public ActionResult Index()
        {
            UrunDetay cs = new UrunDetay();
            cs.Uruns = context.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Detays = context.Detays.Where(y => y.DetayID == 1).ToList() ;
            return View(cs);
        }
    }
}