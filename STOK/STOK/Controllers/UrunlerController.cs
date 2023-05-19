using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STOK.Models.Entity;



namespace STOK.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        DboStokEntities db = new DboStokEntities();
        [Authorize]



        public ActionResult Index(string p)
        {
            //ARAMA KISMI İÇİN...
            var urunler = db.TBL_URUNLER.Where(x => x.DURUM == true);
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.URUNAD.Contains(p) && x.DURUM == true);
            }
            return View(urunler.ToList());
        }


        [HttpGet]  //sayfa yüklenince calışşsın
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.TBL_KATEGORILER.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KATEGORIAD,
                                            Value = x.KATEGORIID.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();


        }




        [HttpPost]
        public ActionResult YeniUrun(TBL_URUNLER p)
        {
            var ktgr = db.TBL_KATEGORILER.Where(x => x.KATEGORIID == p.TBL_KATEGORILER.KATEGORIID).FirstOrDefault();
            p.TBL_KATEGORILER = ktgr;
            p.DURUM = true;
            db.TBL_URUNLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





        public ActionResult Getir(int id)
        {
            List<SelectListItem> katg = (from x in db.TBL_KATEGORILER.ToList()
                select new SelectListItem
                {
                    Text = x.KATEGORIAD,
                    Value = x.KATEGORIID.ToString()
                }).ToList();


            var kategori = db.TBL_URUNLER.Find(id);
            ViewBag.urunkategori = katg;
            return View("Getir", kategori);
        }



        public ActionResult Guncelle(TBL_URUNLER p)
        {
            var urun = db.TBL_URUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.URUNMARKA = p.URUNMARKA;
            urun.URUNSTOK = p.URUNSTOK;
            urun.URUNALISFIYAT = p.URUNALISFIYAT;
            urun.URUNSATISFIYAT = p.URUNSATISFIYAT;
            var ktg = db.TBL_KATEGORILER.Where(x => x.KATEGORIID == p.TBL_KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.KATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            urun.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }

}