﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cari = c.Caris.Where(x => x.Durum == true).ToList();

            return View(cari);
        }

        public ActionResult CariEkle()
        {
            Cari c = new Cari();

            return View(c);
        }

        [HttpPost]
        public ActionResult CariEkle(Cari p)
        {
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var car = c.Caris.Find(id);
            car.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}