using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult CariKayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariKayit(Cari cari)
        {
            cari.Durum = false;
            cari.Sil = false;
            context.Caris.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult CariGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariGiris(Cari cari)
        {
            var bilgiler = context.Caris.FirstOrDefault(x => x.CariMail == cari.CariMail && x.Sifre == cari.Sifre && x.Durum == true && x.Sil == false);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }            
        }
    }
}