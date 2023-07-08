using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context context = new Context();
        public ActionResult Index()
        {
            var liste = context.Faturas.ToList();
            return View(liste);
        }
    }
}