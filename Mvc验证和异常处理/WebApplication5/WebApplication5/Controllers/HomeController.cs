using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : FilterController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //int a = 0;
            //int b = 10 / a;

            ViewBag.Message = "Your application description page.";
            Session["user"] = "zyh";
            return View();
        }
        //[CustomAuthorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}