using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STOK.Models.Entity;

namespace STOK.Controllers
{
    public class AdminController : Controller
    {

        DboStokEntities db = new DboStokEntities();
        [Authorize]

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniAdmin( TBL_ADMIN p)
        {
            db.TBL_ADMIN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}