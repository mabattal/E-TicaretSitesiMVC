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

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            Fatura fatura = new Fatura();

            return View(fatura);
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            context.Faturas.Add(fatura);
            fatura.Tarih = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var deger = context.Faturas.Find(id);
            return View("FaturaEkle",deger);
        }

        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var deger = context.Faturas.Find(fatura.FaturaID);
            deger.FaturaSeriNo = fatura.FaturaSeriNo;
            deger.FaturaSiraNo = fatura.FaturaSiraNo;
            deger.VergiDairesi = fatura.VergiDairesi;
            deger.Tarih = DateTime.Now;
            deger.TeslimEden = fatura.TeslimEden;
            deger.TeslimAlan = fatura.TeslimAlan;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}