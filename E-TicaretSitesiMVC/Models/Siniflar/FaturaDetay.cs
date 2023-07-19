using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_TicaretSitesiMVC.Models.Siniflar
{
    public class FaturaDetay
    {
        [Key]
        public int FaturaDetayID { get; set; }       
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public int FaturaID { get; set; }
        public virtual Fatura Fatura { get; set; }
        public int UrunID { get; set; }
        public virtual Urun Urun { get; set; }
    }
}