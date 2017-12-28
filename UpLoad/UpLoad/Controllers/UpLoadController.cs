using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UpLoad.Controllers
{
    public class UpLoadController : Controller
    {
        //
        // GET: /UpLoad/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UpLoadFile(string url)
        {
            return Json(url);
        }
    }
}
