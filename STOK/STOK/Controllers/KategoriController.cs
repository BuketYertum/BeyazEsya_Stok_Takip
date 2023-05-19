using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STOK.Models.Entity;

namespace STOK.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        DboStokEntities db = new DboStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var kategoriler = db.TBL_KATEGORILER.ToList();
            return View(kategoriler);
        }



        [HttpGet]  //sayfa yüklendiğinde bu çalışsın
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORILER p)
        {
            db.TBL_KATEGORILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Sil(int id)
        {
            var kategori = db.TBL_KATEGORILER.Find(id);
            db.TBL_KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var kategori = db.TBL_KATEGORILER.Find(id);
            return View("Getir", kategori);
        }


        public ActionResult Guncelle(TBL_KATEGORILER k)
        {
            var kategori = db.TBL_KATEGORILER.Find(k.KATEGORIID);
            kategori.KATEGORIAD = k.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}