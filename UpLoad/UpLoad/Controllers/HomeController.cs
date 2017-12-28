using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;


using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections;

namespace UpLoad.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string update()
        {
            string str= Request.Files[0].FileName;
            HttpPostedFileBase files = Request.Files[0];
            files.SaveAs(Server.MapPath("~/App_Data/") + Request.Files[0].FileName);
            return "success";
        }
    }
}
