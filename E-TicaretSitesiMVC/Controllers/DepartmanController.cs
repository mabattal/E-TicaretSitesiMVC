using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            Departman yeniDepartman = new Departman();
            return View(yeniDepartman);
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmans.Find(id);
            return View("DepartmanEkle", dep);
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dep = c.Departmans.Find(d.DepartmanID);
            dep.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            //Seçilen departmana ait personelleri getiriyoruz
            var degerler = c.Personels.Where(x => x.DepartmanID == id).ToList();

            // Seçilen departmanın adını veritabanından alıyoruz
            var departmanAdi = c.Departmans.FirstOrDefault(d => d.DepartmanID == id)?.DepartmanAd;
            ViewBag.DepartmanAdi = departmanAdi;

            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}