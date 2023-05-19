using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STOK.Controllers
{
    public class DefaultController : Controller
    {
        [Authorize]

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}