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

        [HttpGet]
        public ActionResult SatisEkle()
        {
            SatisHareket satisHareket = new SatisHareket();

            //Ürünler dropdown için ürünler listesi
            List<SelectListItem> list1 = (from x in context.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.Urunler = list1;

            //Cariler dropdown için cariler listesi
            List<SelectListItem> list2 = (from x in context.Caris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            ViewBag.Cariler = list2;

            //Personeller dropdown için personeller listesi
            List<SelectListItem> list3 = (from x in context.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAd + " " + x.PersonelSoyad,
                                              Value = x.PersonelID.ToString()
                                          }).ToList();
            ViewBag.Personeller = list3;

            List<SelectListItem> list4 = (from x in context.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()
                                          }).ToList();
            ViewBag.Urunler = list4;

            return View(satisHareket);
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satisHareket)
        {
            //toplamtutar'ı hesaplayabilmek için satın alınan ürünün satışFiyatı gerekiyor
            //satisHareket'ten gelen UrunID ile ürünü var tipinde bir x değişkenine aldım
            var x = context.Uruns.Find(satisHareket.UrunID);
            satisHareket.Fiyat = x.SatisFiyat;                                  
            satisHareket.ToplamTutar = satisHareket.Fiyat * satisHareket.Adet;
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToString());
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            var deger = context.SatisHarekets.Find(id);

            //Ürünler dropdown için ürünler listesi
            List<SelectListItem> list1 = (from x in context.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()
                                          }).ToList();
            ViewBag.Urunler = list1;

            //Cariler dropdown için cariler listesi
            List<SelectListItem> list2 = (from x in context.Caris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CariAd + " " + x.CariSoyad,
                                              Value = x.CariID.ToString()
                                          }).ToList();
            ViewBag.Cariler = list2;

            //Personeller dropdown için personeller listesi
            List<SelectListItem> list3 = (from x in context.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAd + " " + x.PersonelSoyad,
                                              Value = x.PersonelID.ToString()
                                          }).ToList();
            ViewBag.Personeller = list3;

            List<SelectListItem> list4 = (from x in context.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()
                                          }).ToList();
            ViewBag.Urunler = list4;

            return View("SatisEkle",deger);
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            var deger = context.SatisHarekets.Find(satisHareket.SatisID);
            var x = context.Uruns.Find(satisHareket.UrunID);
            deger.UrunID = satisHareket.UrunID;
            deger.CariID = satisHareket.CariID;
            deger.Adet = satisHareket.Adet;
            deger.Fiyat = x.SatisFiyat;
            deger.PersonelID = satisHareket.PersonelID;
            deger.Tarih = DateTime.Parse(DateTime.Now.ToString());
            deger.ToplamTutar = deger.Fiyat * deger.Adet;
            context.SaveChanges();

            return RedirectToAction("Index");            
        }

        public ActionResult SatisDetay(int id)
        {
            var deger = context.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(deger);
        }
    }
}