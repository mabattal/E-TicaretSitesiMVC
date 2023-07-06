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
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Departmans.Where(x => x.Sil == false).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            Departman departman = new Departman();

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem{Text = "Aktif", Value="True"},
                new SelectListItem{Text = "Pasif", Value="False"}
            };
            ViewBag.Durum = durumlar;

            return View(departman);
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dep = context.Departmans.Find(id);

            List<SelectListItem> durumlar = new List<SelectListItem>
            {
                new SelectListItem{Text = "Aktif", Value="True"},
                new SelectListItem{Text = "Pasif", Value="False"}
            };
            ViewBag.Durum = durumlar;

            return View("DepartmanEkle", dep);
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = context.Departmans.Find(id);
            dep.Sil = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dep = context.Departmans.Find(departman.DepartmanID);
            dep.DepartmanAd = departman.DepartmanAd;
            dep.Durum = departman.Durum;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            //Seçilen departmana ait personelleri getiriyoruz
            var degerler = context.Personels.Where(x => x.DepartmanID == id).ToList();

            // Seçilen departmanın adını veritabanından alıyoruz
            var departmanAdi = context.Departmans.FirstOrDefault(d => d.DepartmanID == id)?.DepartmanAd;
            ViewBag.DepartmanAdi = departmanAdi;

            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var per = context.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}