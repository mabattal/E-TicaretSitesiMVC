using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_TicaretSitesiMVC.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }
        public string CariAd { get; set; }
        public string CariSoyad { get; set; }
        public string CariSehir { get; set; }
        public string CariMail { get; set; }
        public SatisHareket SatisHareket { get; set; }
    }
}