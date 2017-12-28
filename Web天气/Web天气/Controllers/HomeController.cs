using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web天气.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            WeatherService.WeatherWebService w = new WeatherService.WeatherWebService();
            string[] res = new string[23];
            res = w.getWeatherbyCityName("北京");
            ViewBag.Message = "北京今天的天气"+res[6];

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}