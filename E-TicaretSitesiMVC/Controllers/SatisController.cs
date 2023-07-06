using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.SatisHarekets.ToList();
            return View(degerler);
        }
    }
}