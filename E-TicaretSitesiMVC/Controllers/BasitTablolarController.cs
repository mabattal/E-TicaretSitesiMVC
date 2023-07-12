using E_TicaretSitesiMVC.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class BasitTablolarController : Controller
    {
        // GET: BasitTablolar
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DepartmanPartial()
        {
            var sorgu2 = from x in context.Personels.Where(x => x.Sil == false && x.Durum == true)
                         group x by x.Departman.DepartmanAd into g
                         select new DepartmanGrup
                         {
                             Departman = g.Key,
                             Adet = g.Count(),
                             ToplamAdet = context.Personels.Count(x => x.Sil == false && x.Durum == true)

                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult CariPartial()
        {
            var sorgu = from x in context.Caris.Where(x => x.Sil == false && x.Durum == true)
                        group x by x.CariSehir into g
                        select new CariGrup
                        {
                            Sehir = g.Key,
                            Adet = g.Count(),
                            ToplamAdet = context.Caris.Count(x => x.Sil == false && x.Durum == true)
                        };

            return PartialView(sorgu.ToList());

        }

        public PartialViewResult KategoriPartial()
        {
            var sorgu3 = from x in context.Uruns
                         group x by x.Kategori.KategoriAd into g
                         select new KategoriGrup
                         {
                             Kategori = g.Key,
                             Adet = g.Count(),
                             ToplamAdet = context.Uruns.Count(x => x.Sil == false && x.Durum == true)
                         };

            return PartialView(sorgu3.ToList());
        }

        public PartialViewResult PersonelPartial()
        {
            var sorgu = context.Personels.Where(x => x.Sil == false && x.Durum == true).ToList();
            return PartialView(sorgu.ToList());
        }

        public PartialViewResult UrunPartial()
        {
            var sorgu = context.Uruns.Where(x => x.Sil == false).ToList();
            return PartialView(sorgu.ToList());
        }
    }
}