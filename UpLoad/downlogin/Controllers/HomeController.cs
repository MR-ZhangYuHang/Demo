using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace downlogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string filePath = "";
            //string absoluFilePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["AttachmentPath"] + filePath);
            //return File(new FileStream(absoluFilePath, FileMode.Open), "application/octet-stream", Server.UrlEncode(fileName));
            ExportDemo1();
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
            GetFile();
            return View();
        }



        public FileResult GetFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/uploads/";
            string fileName = "基站信息Excel模版.xls";
            return File(path + fileName, "text/plain", fileName);
        }


        public ActionResult ExportDemo1()
        {

            System.IO.MemoryStream output = new System.IO.MemoryStream();

            System.IO.StreamWriter writer = new System.IO.StreamWriter(output, System.Text.Encoding.UTF8);

            writer.Write("姓名,性别,年龄");//输出标题，逗号分割（注意最后一列不加逗号）

            writer.WriteLine();



            //输出内容

            for (int i = 0; i < 10; i++)
            {

                writer.Write("用户" + i + ",\"");//第一列

                writer.Write("男\",\"");//中间列

                writer.Write("20\",");//最后一列

                writer.WriteLine();

            }



            writer.Flush();

            output.Position = 0;

            return File(output, "text/comma-separated-values", "demo1.csv");

        }
    }
}