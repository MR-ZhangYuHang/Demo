using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisDemo.Controllers
{
    public class HomeController : Controller
    {
        RedisClient client = new RedisClient("192.168.1.41", 6379);
        public ActionResult Index()
        {
            client.EnqueueItemOnList("que", "zyh");
            client.EnqueueItemOnList("que", "zdm");
            List<string> strarry = client.GetAllItemsFromList("que");
            DateTime dt1=DateTime.Now;
            client.Set<DateTime>("dt1", dt1);
            client.Set<string>("dt2", dt1.ToString());
            ViewBag.Message = "DATETIME NOW." + dt1.ToString();
            client.AddItemToSet("a3", "ddd");
            client.AddItemToSet("a3", "ccc");
            client.AddItemToSet("a3", "tttt");
            client.AddItemToSet("a3", "sssh");
            client.AddItemToSet("a3", "hhhh");
            client.AddItemToSet("a4", "hhhh");
            client.AddItemToSet("a4", "h777");
            return View(dt1);
        }

        public ActionResult About()
        {
            DateTime dt1 = client.Get<DateTime>("dt1");
            client.DequeueItemFromList("que");
            List<string>strarry= client.GetAllItemsFromList("que");
            ViewBag.Message = "Your application description page."+dt1.ToString()+"===";
            Console.WriteLine("-------------求a3集合------------");

            HashSet<string> hashSet = client.GetAllItemsFromSet("a3");
            foreach (string value in hashSet)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("-------------求并集------------");

            hashSet.Clear();
            hashSet = client.GetUnionFromSets(new string[] { "a3", "a4" });
            foreach (string value in hashSet)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("-------------求交集------------");

            hashSet.Clear();
            hashSet = client.GetIntersectFromSets(new string[] { "a3", "a4" });
            foreach (string value in hashSet)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("-------------求差集------------");

            hashSet.Clear();
            hashSet = client.GetDifferencesFromSet("a3", new string[] { "a4" });
            foreach (string value in hashSet)
            {
                Console.WriteLine(value);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}