using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using E_TicaretSitesiMVC.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace E_TicaretSitesiMVC.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context context = new Context();
        public ActionResult Index(int sayfa = 1, string parametre = "")
        {
            var faturalar = from x in context.Faturas select x;
            if (!string.IsNullOrEmpty(parametre))
            {
                faturalar = faturalar.Where(x => (x.FaturaSeriNo + x.FaturaSiraNo).Contains(parametre));
            }
            return View(faturalar.ToList().ToPagedList(sayfa, 8));
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            Fatura fatura = new Fatura();

            return View(fatura);
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            context.Faturas.Add(fatura);
            fatura.Tarih = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var deger = context.Faturas.Find(id);
            return View("FaturaEkle",deger);
        }

        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var deger = context.Faturas.Find(fatura.FaturaID);
            deger.FaturaSeriNo = fatura.FaturaSeriNo;
            deger.FaturaSiraNo = fatura.FaturaSiraNo;
            deger.VergiDairesi = fatura.VergiDairesi;
            deger.Tarih = DateTime.Now;
            deger.TeslimEden = fatura.TeslimEden;
            deger.TeslimAlan = fatura.TeslimAlan;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var kalem = context.FaturaDetays.Where(x => x.FaturaID == id).ToList();
            ViewBag.FaturaID = id;
            var fatura = context.Faturas.Find(id);
            ViewBag.serisira = fatura.FaturaSeriNo+fatura.FaturaSiraNo;
            return View(kalem);
        }

        [HttpGet]
        public ActionResult FaturaDetayEkle(int faturaID)
        {
            FaturaDetay faturaDetay = new FaturaDetay();

            //Ürünler dropdown için ürünler listesi
            List<SelectListItem> list1 = (from x in context.Uruns.Where(x => x.Durum == true && x.Sil == false).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()
                                          }).ToList();
            ViewBag.Urunler = list1;            

            var fatura = context.Faturas.Find(faturaID);
            ViewBag.serisira = fatura.FaturaSeriNo + fatura.FaturaSiraNo;
            ViewBag.FaturaID = faturaID;

            return View(faturaDetay);
        }

        [HttpPost]
        public ActionResult FaturaDetayEkle(FaturaDetay faturaDetay)
        {
            
            //tutar'ı hesaplayabilmek için satın alınan ürünün satışFiyatı gerekiyor
            //faturaDetay'ten gelen UrunID ile ürünü var tipinde bir x değişkenine aldım
            var x = context.Uruns.Find(faturaDetay.UrunID);
            faturaDetay.BirimFiyat = x.SatisFiyat;
            faturaDetay.Tutar = faturaDetay.BirimFiyat * faturaDetay.Miktar;
            faturaDetay.FaturaID = faturaDetay.FaturaID;
            context.FaturaDetays.Add(faturaDetay);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}