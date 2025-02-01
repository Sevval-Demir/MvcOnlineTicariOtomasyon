using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        //ürün tablosu ile ilişkilendirme   
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public Decimal Fiyat { get; set; }
        public Decimal ToplamTutar { get; set; }
        public ICollection<Urun> Uruns { get; set; }
        public ICollection<Cariler> Carilers { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}