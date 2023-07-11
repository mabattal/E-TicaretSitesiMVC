using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretSitesiMVC.Models.Siniflar
{
    //iki farklı veri tipini tek bir sınıfta birleştirmek
    public class Class1
    {
        public IEnumerable<Urun> Uruns { get; set; }
        public IEnumerable<Detay> Detays { get; set;}
    }
}