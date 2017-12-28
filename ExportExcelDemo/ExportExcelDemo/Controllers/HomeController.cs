using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.OleDb;

namespace ExportExcelDemo.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult ExportExcel()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("age", typeof(int));
            dt.Columns.Add("phone");
            dt.Rows.Add("老张", 40, "99213812");
            dt.Rows.Add("小李", 28, "a21313");
            dt.Rows.Add("小王", 22, "2131434");

            string FileName = Guid.NewGuid().ToString() + ".xls";

            string sNewFullFile = Server.MapPath(FileName);
            try
            {
                System.IO.File.Copy(Server.MapPath("format.xlsx"), sNewFullFile);
            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }
            string strConn = "Provider=Microsoft.Jet.OLEDB.12.0;Persist Security Info=True;Data Source=" + sNewFullFile + ";Extended Properties=Excel 8.0;HDR=Yes;IMEX=1;";
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
            OleDbCommand cmd = null;

            bool bRet = false;
            try
            {
                conn.Open();

                cmd = new OleDbCommand(" create table [sheet4]([姓名] Text,[年龄] int,[电话] Text)", conn);
                cmd.ExecuteNonQuery();

                string strSQL = " INSERT INTO [Sheet4$] ([姓名], [年龄],[电话]) VALUES (?, ?, ?)";

                cmd = new OleDbCommand(strSQL, conn);

                for (int i = 0; i < 3; i++)
                {
                    cmd.Parameters.Add(i.ToString(), OleDbType.VarChar);
                }



                DataView dv = dt.DefaultView;
                foreach (DataRowView row in dv)
                {

                    cmd.Parameters[0].Value = row["name"].ToString();
                    cmd.Parameters[1].Value = (int)row["age"];
                    cmd.Parameters[2].Value = row["phone"].ToString();
                    cmd.ExecuteNonQuery();
                }
                bRet = true;


            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                conn.Dispose();

            }
            if (bRet)
                Response.Redirect(FileName);
            return View();
        }
    }
}