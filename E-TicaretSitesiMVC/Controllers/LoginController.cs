using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult KayitOlPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult KayitOlPartial(Cari cari)
        {
            cari.Durum = false;
            cari.Sil = false;
            context.Caris.Add(cari);
            context.SaveChanges();
            return PartialView();
        }
    }
}