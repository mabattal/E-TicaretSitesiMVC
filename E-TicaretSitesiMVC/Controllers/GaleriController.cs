using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context context = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = context.Uruns.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 9);
            return View(degerler);
        }
    }
}