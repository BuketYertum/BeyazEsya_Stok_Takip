using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STOK.Models.Entity;
using System.Web.Security;


namespace STOK.Controllers
{
    public class GirisYapController : Controller
    {

        DboStokEntities db = new DboStokEntities();
        // GET: GirisYap
        public ActionResult Giris()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Giris(TBL_ADMIN p)
        {
            var bilgiler = db.TBL_ADMIN.FirstOrDefault(x => x.KULLANICI == p.KULLANICI && x.SIFRE == p.SIFRE); 
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                return RedirectToAction("Index", "Urunler");
            }
            else
            {
                return View();
            }
            
        }



        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Giris", "GirisYap");
        }
    }
}