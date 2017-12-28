using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using UpLoad.Models;
using Word = Microsoft.Office.Interop.Word;
using Aspose.Words;

namespace UpLoad.Controllers
{
    public class DownLoadController : Controller
    {
        //
        // GET: /DownLoad/

        public ActionResult Index()
        {
            return View();
        }

        public string Login(int id)
        {
           
            DownFile DFile = GetHtml(id);
            Microsoft.Office.Interop.Word.ApplicationClass AppClass = new Microsoft.Office.Interop.Word.ApplicationClass();//实例化一个Word
            Type wordtype = AppClass.GetType();
            Microsoft.Office.Interop.Word.Documents docs = AppClass.Documents;//获取Document
            Type docstype = docs.GetType();
            object FileName = System.Web.HttpContext.Current.Server.MapPath(DFile.path);//Word文件的路径
            Microsoft.Office.Interop.Word.Document doc = (Microsoft.Office.Interop.Word.Document)docstype.InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new object[] { FileName, true, true });//打开文件
            Type doctype = doc.GetType();
            string[] strSaveFileNameArry = FileName.ToString().Split('.');
            string strSaveFileName = "";
            for (int i = 0; i < strSaveFileNameArry.Length - 1; i++)
            {
                strSaveFileName += strSaveFileNameArry[i].ToString();
            }
            object SaveFileName = strSaveFileName+".html";//生成HTML的路径和名子
            doctype.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { SaveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML });//另存为Html格式
            doctype.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod,null, doc, new object[] { null, null, null });  //关闭word文档
            wordtype.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, AppClass, null);//退出
            StreamReader objreader = new StreamReader(SaveFileName.ToString(), System.Text.Encoding.GetEncoding("UTF-8"));  //以下内容是为了在Html中加入对本身Word文件的下载      
            FileStream fs = new FileStream(SaveFileName.ToString().Split('.').GetValue(0).ToString() + "$.html", FileMode.Create);
            StreamWriter streamHtmlHelp = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("UTF-8"));
            string str = "";
            do
            {
                str = objreader.ReadLine();
                if (str=="<meta http-equiv=Content-Type content=\"text/html; charset=gb2312\">")
                {
                    str = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=unicode\" />";
                }
                if (str=="<meta http-equiv=Content-Type content=\"text/html; charset=x-cp20936\">")
                {
                    str = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />";
                }
                streamHtmlHelp.WriteLine(str);
            }
            while (str != "</html>");
            streamHtmlHelp.Close();
            objreader.Close();
            System.IO.File.Delete(SaveFileName.ToString());
            System.IO.File.Move(SaveFileName.ToString().Split('.').GetValue(0).ToString() + "$.html", SaveFileName.ToString());

            return JsonConvert.SerializeObject(DFile);
        }
        public ActionResult GetPdf(int id)
        {
            DownFile dfile = GetHtml(id);
            return new FilePathResult(System.Web.HttpContext.Current.Server.MapPath(dfile.path), "application/pdf");

        }

        public DownFile GetHtml(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=.;database=DownFile;uid=sa;pwd=sa123;";
            conn.Open();
            string sql = "select * from DownFileNews where id=@id";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlParameter sp = new SqlParameter("@id", id);
            comm.Parameters.Add(sp);
            SqlDataReader sdr = comm.ExecuteReader();
            DownFile df = new DownFile();
            if (sdr.Read())
            {
                df.id = sdr.GetInt32(0);
                df.path = sdr.GetString(1);
                df.name = sdr.GetString(2);
                df.updatetime = sdr.GetDateTime(3);
                df.source = sdr.GetString(4);
                df.htmlpath = sdr.GetString(5);
            }
            sdr.Close();
            conn.Close();
            return df;

        }

        public string HtmlToPDF(int id)
        {
            DownFile DFile = GetHtml(id);
            string relativePath =DFile.path; //相对路径，从url获取  
                if (relativePath == "" || relativePath == null)  
                    return "地址错误";  
                string serverPath = Server.MapPath(relativePath);
                string[] strSaveFileNameArry = serverPath.ToString().Split('.');

                string pdfPath = serverPath.Replace("."+strSaveFileNameArry[strSaveFileNameArry.Length-1], ".pdf");  
                if (!System.IO.File.Exists(@pdfPath))//存在PDF，不需要继续转换  
                {  
                    if (!CreatePDF(serverPath, pdfPath)) //函数在底下  
                    {  
                        return "";  
                    }  
                }
                relativePath = relativePath.Replace("." + strSaveFileNameArry[strSaveFileNameArry.Length - 1], ".pdf");  
                relativePath = relativePath.Remove(0, 2);
                return "转换成功"; 
           // Aspose.Words.Document doc = new Aspose.Words.Document(被转换文件的路径+名字);   
            //doc.Save(保存pdf的路径+名字, SaveFormat.Pdf);  
        }

        public bool CreatePDF(string soursePath, string savePath)  
        {  
  
  
            try  
            {  
                Aspose.Words.Document doc = new Aspose.Words.Document(soursePath);  
                //保存PDF文件  
                doc.Save(savePath);  
                return true;  
            }  
            catch (Exception ex)  
            {  
                return false;  
            }   
        }


    }
}
