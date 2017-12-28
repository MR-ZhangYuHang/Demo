using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SqlDependencyTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            //ALTER DATABASE MvcDemo SET NEW_BROKER WITH ROLLBACK IMMEDIATE;
            //ALTER DATABASE MvcDemo SET ENABLE_BROKER;
            ViewBag.Message = "Your application description page.";
            string _connStr = "server=.; database=MvcDemo;pwd=sa123;uid=sa;";
            string sql = "";
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                //依赖是基于某一张表的,而且查询语句只能是简单查询语句,不能带top或*,同时必须指定所有者,即类似[dbo].[]  
                using (SqlCommand command = new SqlCommand("select ID,[UserName],[Email] From [dbo].[SysUser]", connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    SqlDependency.Start(_connStr);
                    SqlDataReader sdr = command.ExecuteReader();
                    Console.WriteLine();
                    
                    while (sdr.Read())
                    {
                        sql+="Id:"+sdr["ID"].ToString()+"UserId:"+sdr["UserName"].ToString()+"Message:"+sdr["Email"].ToString()+"/n";
                    }
                    sdr.Close();
                }
            }
            if (Request.Cookies["sql"] == null)
            {
                HttpCookie cookies = new HttpCookie("sql");
                cookies.Value= HttpUtility.UrlEncode(sql);
            }
            else
            {
                HttpCookie cookies = Request.Cookies["sql"];
                cookies.Value = "11123344";
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            alert("1");
        }
        public void alert(string a)
        {
            HttpCookie cookies = new HttpCookie("UserNo");
            cookies.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookies);
        }
    }
}