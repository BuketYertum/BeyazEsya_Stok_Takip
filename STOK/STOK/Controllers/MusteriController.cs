using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STOK.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace STOK.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DboStokEntities db = new DboStokEntities();
        [Authorize]

        public ActionResult Index(int sayfa=1)//sayfalama işleminin kaçıncı sayfadan baslicana karar veriyor.
        { 
            var musteriliste = db.TBL_MUSTERILER.Where(x=>x.DURUM == true).ToList().ToPagedList(sayfa, 6);//sayfada 3 baslık gözükcek.
            return View(musteriliste);
        }



        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERILER p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.DURUM = true;
            db.TBL_MUSTERILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        
        public ActionResult Sil(int id)
        {
            var musteribul = db.TBL_MUSTERILER.Find(id);
            musteribul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Getir(int id)
        {
            var musteri = db.TBL_MUSTERILER.Find(id);
            return View("Getir", musteri);
        }



        public ActionResult Guncelle(TBL_MUSTERILER p)
        {
            var musteri = db.TBL_MUSTERILER.Find(p.MUSTERIID);
            musteri.MUSTERIAD = p.MUSTERIAD;
            musteri.MUSTERISOYAD = p.MUSTERISOYAD;
            musteri.MUSTERISEHIR = p.MUSTERISEHIR;
            musteri.MUSTERIBAKIYE = p.MUSTERIBAKIYE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}