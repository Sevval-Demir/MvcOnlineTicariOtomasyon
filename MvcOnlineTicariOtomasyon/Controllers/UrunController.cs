using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c=new Context();
        public ActionResult Index()
        {
            var urun = c.Uruns.Where(x=>x.UrunDurum==true).ToList();
            return View(urun);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            c.Uruns.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger=c.Uruns.Find(id);
            deger.UrunDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger=c.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            var value = c.Uruns.Find(urun.UrunID);
            value.UrunAlisFiyat=urun.UrunAlisFiyat;
            value.UrunDurum=urun.UrunDurum;
            value.KategoriId =urun.KategoriId;
            value.UrunMarka=urun.UrunMarka;
            value.UrunSatisFiyat = urun.UrunSatisFiyat;
            value.UrunStok=urun.UrunStok;
            value.UrunAd=urun.UrunAd;
            value.UrunGorsel=urun.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}