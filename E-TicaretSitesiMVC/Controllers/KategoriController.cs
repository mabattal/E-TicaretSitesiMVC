using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context context = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = context.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        //[HttpGet]
        public ActionResult KategoriEkle()
        {
            Kategori kategori = new Kategori();
            return View(kategori);
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kat = context.Kategoris.Find(id);
            context.Kategoris.Remove(kat);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //Güncelle butonuna basıldığında seçilen kategoriyi KategoriEkle View'ine gönderiyoruz
        //Böylelikle tek sayfada hem yeni kayıt hem de güncelleme yapmış olduk
        public ActionResult KategoriGetir(int id)
        {
            var kat = context.Kategoris.Find(id);
            return View("KategoriEkle",kat);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var kat = context.Kategoris.Find(kategori.KategoriID);
            kat.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}