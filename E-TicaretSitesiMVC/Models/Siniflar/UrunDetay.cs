using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretSitesiMVC.Models.Siniflar
{
    //iki farklı veri tipini tek bir sınıfta birleştirmek
    public class UrunDetay
    {
        public IEnumerable<Urun> Uruns { get; set; }
        public IEnumerable<Detay> Detays { get; set;}
    }
}