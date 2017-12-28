using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BLL;

namespace ProblemAnalysis.Controllers
{
    public class HomeController : Controller
    {
        ProblemBLL bll = new ProblemBLL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult GetTable(string title,int page) {
            DataSet ds = bll.GetTable(title,page);
            return Content(JsonConvert.SerializeObject(ds),"text/html");
        }
        [HttpPost]
        public ActionResult SumitProblem(int id,string title,string edit1,string edit2) {
            int i = bll.SumitProblem(id,title, edit1, edit2);
            if (i>0)
            {
                if (id == 0)
                    return Json("添加成功");
                else
                    return Json("修改成功");

            }
            else
            {
                if (id == 0)
                    return Json("添加失败");
                else
                    return Json("修改失败");
            }
        }
        [HttpPost]
        public ActionResult GetLine(int id) {
            DataSet ds = bll.GetLine(id);
            return Content(JsonConvert.SerializeObject(ds), "text/html");
        }
        [HttpPost]
        public ActionResult DeleteLine(int id) {
            int i = bll.DeleteLine(id);
            if (i > 0)
                return Json("删除成功");
            else
                return Json("删除失败");
        }
        public ActionResult TopLine(int id)
        {
            int i = bll.TopLine(id);
            if (i > 0)
                return Json("置顶成功");
            else
                return Json("置顶失败");
        }
    }
}