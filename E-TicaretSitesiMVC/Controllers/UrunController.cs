﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            Urun yeniUrun = new Urun();

            // Dropdown için seçenekleri oluşturuyoruz
            List<SelectListItem> kategoriler = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            // ViewBag üzerinden seçenekleri View'a gönderiyoruz
            ViewBag.ktg = kategoriler;
                        
            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem { Text = "Aktif", Value = "true" },
                new SelectListItem { Text = "Pasif", Value = "false" }
            };
            
            ViewBag.Durumlar = durumlar;

            return View(yeniUrun);
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            // Dropdown için seçenekleri oluşturuyoruz
            List<SelectListItem> kategoriler = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            // ViewBag üzerinden seçenekleri View'a gönderiyoruz
            ViewBag.ktg = kategoriler;

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem { Text = "Aktif", Value = "true" },
                new SelectListItem { Text = "Pasif", Value = "false" }
            };

            ViewBag.Durumlar = durumlar;

            var urun = c.Uruns.Find(id);
            return View("UrunEkle", urun);
        }

        public ActionResult UrunGuncelle(Urun u)
        {
            var urun = c.Uruns.Find(u.UrunID);
            urun.UrunAd = u.UrunAd;
            urun.Marka = u.Marka;
            urun.Stok = u.Stok;
            urun.AlisFiyat = u.AlisFiyat;
            urun.SatisFiyat = u.SatisFiyat;
            urun.KategoriID = u.KategoriID;
            urun.UrunGorsel = u.UrunGorsel;
            urun.Durum = u.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}