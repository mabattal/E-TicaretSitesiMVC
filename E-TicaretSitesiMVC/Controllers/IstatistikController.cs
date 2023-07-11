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
            //Cari Sayısı
            ViewBag.d1 = context.Caris
                .Where(x => x.Sil == false).Count().ToString();

            //Ürün Sayısı
            ViewBag.d2 = context.Uruns
                .Where(x => x.Sil == false).Count().ToString();

            //Personel Sayısı
            ViewBag.d3 = context.Personels
                .Where(x => x.Sil == false).Count().ToString();

            //Kategori Sayısı
            ViewBag.d4 = context.Kategoris.Count().ToString();

            //Toplam Stok
            ViewBag.d5 = context.Uruns
                .Where(x => x.Sil == false && x.Durum == true)
                .Sum(x => x.Stok).ToString();

            //Marka Sayısı
            ViewBag.d6 = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();

            //Stok Kritik Seviye
            ViewBag.d7 = context.Uruns
                .Where(x => x.Sil == false && x.Durum == true && x.Stok < 20).Count().ToString();

            //En Pahalı Ürün (Fiyat)
            ViewBag.d8 = (from x in context.Uruns
                          .Where(x => x.Sil == false && x.Durum == true)
                          select x.SatisFiyat).Max().ToString();

            //En Ucuz Ürün (Fiyat)
            ViewBag.d9 = (from x in context.Uruns
                          .Where(x => x.Sil == false && x.Durum == true)
                          select x.SatisFiyat).Min().ToString();

            //En Fazla Ürün (Marka)
            ViewBag.d10 = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();

            //En Pahalı Ürün (Stok)
            ViewBag.d11 = (from x in context.Uruns
                           .Where(x => x.Sil == false && x.Durum == true)
                           orderby x.SatisFiyat descending
                           select x.Stok).FirstOrDefault();

            //En Ucuz Ürün (Stok)
            ViewBag.d12 = (from x in context.Uruns
                           .Where(x => x.Sil == false && x.Durum == true)
                           orderby x.SatisFiyat ascending
                           select x.Stok).FirstOrDefault();

            //En Çok Satan (Ürün)
            ViewBag.d13 = context.Uruns
                .Where(u => u.UrunID == (context.SatisHarekets.GroupBy(x => x.UrunID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault()))
                .Select(k => k.UrunAd).FirstOrDefault();

            //Aylık Satış Tutarı
            DateTime bugun = DateTime.Today;
            int gun = bugun.Day;
            int ay = bugun.Month;
            int yil = bugun.Year;
            ViewBag.d14 = context.SatisHarekets
                .Where(x => x.Tarih.Month == ay && x.Tarih.Year == yil)
                .Sum(x => (decimal?)x.ToplamTutar) ?? 0;

            //Bugünkü Kasa
            decimal toplamTutar = context.SatisHarekets
                            .Where(x => x.Tarih.Day == gun && x.Tarih.Month == ay && x.Tarih.Year == yil)
                            .Sum(x => (decimal?)x.ToplamTutar) ?? 0;
            ViewBag.d15 = toplamTutar.ToString();


            //Bugünkü Satış Adedi
            ViewBag.d16 = context.SatisHarekets
                .Where(x => x.Tarih.Day == gun && x.Tarih.Month == ay && x.Tarih.Year == yil).Count().ToString();

            return View();
        }

        public ActionResult BasitTablolar()
        {
            var sorgu = from x in context.Caris.Where(x => x.Sil == false && x.Durum == true)
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Adet = g.Count()
                        };

            return View(sorgu.ToList());

        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}