using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        //[HttpGet]
        public ActionResult KategoriEkle()
        {
            Kategori yeniKategori = new Kategori();
            return View(yeniKategori);
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kat = c.Kategoris.Find(id);
            c.Kategoris.Remove(kat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        //Güncelle butonuna basıldığında seçilen kategoriyi KategoriEkle View'ine gönderiyoruz
        //Böylelikle tek sayfada hem yeni kayıt hem de güncelleme yapmış olduk
        public ActionResult KategoriGetir(int id)
        {
            var kat = c.Kategoris.Find(id);
            return View("KategoriEkle",kat);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kat = c.Kategoris.Find(k.KategoriID);
            kat.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}