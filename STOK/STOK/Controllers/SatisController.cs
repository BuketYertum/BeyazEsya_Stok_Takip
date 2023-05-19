using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STOK.Models.Entity;

namespace STOK.Controllers
{
    public class SatisController : Controller
    {
        DboStokEntities db = new DboStokEntities();
        [Authorize]


        // GET: Satis
        public ActionResult Index()
        {
            var satis = db.TBL_SATIS.ToList();
            return View(satis);
        }



        [HttpGet]
        public ActionResult YeniSatis()
        {
            //ÜRÜNLER İÇİN 
            List<SelectListItem> urun = (from x in db.TBL_URUNLER.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.URUNAD,
                                            Value = x.URUNID.ToString()
                                        }).ToList();
            ViewBag.drop1 = urun;


            //PERSONELLER İÇİN
            List<SelectListItem> pers = (from x in db.TBL_PERSONELLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = (x.PERSONELAD +" "+ x.PERSONELSOYAD),
                                                 Value = x.PERSONELID.ToString()
                                             }).ToList();
            ViewBag.drop2 = pers;



            //MÜŞTERİLER İÇİN 
            List<SelectListItem> must = (from x in db.TBL_MUSTERILER.ToList()
                                         select new SelectListItem
                                         {
                                             Text = (x.MUSTERIAD +" "+ x.MUSTERISOYAD),
                                             Value = x.MUSTERIID.ToString()
                                         }).ToList();
            ViewBag.drop3 = must;


           


            return View();
        }




        [HttpPost]
        public ActionResult YeniSatis(TBL_SATIS p)
        {
            var urun = db.TBL_URUNLER.Where(x => x.URUNID== p.TBL_URUNLER.URUNID).FirstOrDefault();
            var must = db.TBL_MUSTERILER.Where(x => x.MUSTERIID == p.TBL_MUSTERILER.MUSTERIID).FirstOrDefault();
            var pers = db.TBL_PERSONELLER.Where(x => x.PERSONELID == p.TBL_PERSONELLER.PERSONELID).FirstOrDefault();
            p.TBL_URUNLER = urun;
            p.TBL_MUSTERILER = must;
            p.TBL_PERSONELLER = pers;
            p.FIYAT = urun.URUNSATISFIYAT;
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_SATIS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}