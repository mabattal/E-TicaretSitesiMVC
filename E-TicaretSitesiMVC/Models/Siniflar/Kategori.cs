using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_TicaretSitesiMVC.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}