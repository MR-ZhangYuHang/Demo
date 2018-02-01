using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFcoreDemo.Models;
using EFcoreDemo.Models2;
using ServiceStack.Redis;

namespace EFcoreDemo.Controllers
{
    public class HomeController : Controller
    {
        RedisClient RC = new RedisClient("192.168.1.41",6379);
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            string name= RC.Get<string>("name");
            XuNiShiYan1Context db = new XuNiShiYan1Context();
            var result = db.User.Where(a=>a.Id!=0);
            string str = null;
            foreach (var item in result)
            {
                str += item.RealName;
            }
            ViewData["Message"] = name+ str;

            return View();
        }

        public IActionResult Contact()
        {

            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
