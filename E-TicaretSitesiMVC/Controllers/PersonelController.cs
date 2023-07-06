using E_TicaretSitesiMVC.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context context = new Context();
        public ActionResult Index()
        {
            var deger = context.Personels.Where(x => x.Sil == false).ToList();
            return View(deger);
        }
    }
}