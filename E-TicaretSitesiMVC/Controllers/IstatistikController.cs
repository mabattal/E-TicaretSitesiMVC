using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretSitesiMVC.Models.Siniflar;

namespace E_TicaretSitesiMVC.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context context = new Context();
        public ActionResult Index()
        {            
            ViewBag.d1 = context.Caris
                .Where(x => x.Sil == false).Count().ToString();

            ViewBag.d2 = context.Uruns
                .Where(x => x.Sil == false).Count().ToString();

            ViewBag.d3 = context.Personels
                .Where(x => x.Sil == false).Count().ToString();

            ViewBag.d4 = context.Kategoris.Count().ToString();

            ViewBag.d5 = context.Uruns
                .Where(x => x.Sil == false && x.Durum == true)
                .Sum(x => x.Stok).ToString();

            ViewBag.d6 = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();

            ViewBag.d7 = context.Uruns
                .Where(x => x.Sil == false && x.Durum == true && x.Stok < 20).Count().ToString();

            ViewBag.d8 = (from x in context.Uruns
                          .Where(x => x.Sil == false && x.Durum == true)
                          select x.SatisFiyat).Max().ToString();

            ViewBag.d9 = (from x in context.Uruns
                          .Where(x => x.Sil == false && x.Durum == true)
                          select x.SatisFiyat).Min().ToString();

            ViewBag.d10 = 9191919191;

            ViewBag.d11 = (from x in context.Uruns
                           .Where(x => x.Sil == false && x.Durum == true)
                           orderby x.SatisFiyat descending
                           select x.Stok).FirstOrDefault();

            ViewBag.d12 = (from x in context.Uruns
                           .Where(x => x.Sil == false && x.Durum == true)
                           orderby x.SatisFiyat ascending
                           select x.Stok).FirstOrDefault();

            ViewBag.d13 = 9191919191;


            DateTime bugun = DateTime.Today;
            int gun = bugun.Day;
            int ay = bugun.Month;
            int yil = bugun.Year;

            ViewBag.d14 = context.SatisHarekets
                .Where(x => x.Tarih.Month == ay && x.Tarih.Year == yil)
                .Sum(x => (decimal?)x.ToplamTutar) ?? 0;

            decimal toplamTutar = context.SatisHarekets
                            .Where(x => x.Tarih.Day == gun && x.Tarih.Month == ay && x.Tarih.Year == yil)
                            .Sum(x => (decimal?)x.ToplamTutar) ?? 0;
            ViewBag.d15 = toplamTutar.ToString();

            ViewBag.d16 = context.SatisHarekets.Where(x => x.Tarih.Day == gun && x.Tarih.Month == ay && x.Tarih.Year == yil).Count().ToString();

            return View();
        }
    }
}