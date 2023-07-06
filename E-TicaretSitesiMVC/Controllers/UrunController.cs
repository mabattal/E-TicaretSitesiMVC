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
        Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(x => x.Sil == false).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            Urun urun = new Urun();

            // Dropdown için seçenekleri oluşturuyoruz
            List<SelectListItem> kategoriler = (from x in context.Kategoris.ToList()
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

            return View(urun);
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = context.Uruns.Find(id);
            deger.Sil = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var deger = context.Uruns.Find(id);

            // Dropdown için seçenekleri oluşturuyoruz
            List<SelectListItem> kategoriler = (from x in context.Kategoris.ToList()
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
                        
            return View("UrunEkle", deger);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var deger = context.Uruns.Find(urun.UrunID);
            deger.UrunAd = urun.UrunAd;
            deger.Marka = urun.Marka;
            deger.Stok = urun.Stok;
            deger.AlisFiyat = urun.AlisFiyat;
            deger.SatisFiyat = urun.SatisFiyat;
            deger.KategoriID = urun.KategoriID;
            deger.UrunGorsel = urun.UrunGorsel;
            deger.Durum = urun.Durum;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}