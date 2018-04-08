using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// 全局异常处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender,EventArgs e) {
            var lastError = Server.GetLastError();
            if (lastError!=null)
            {

                var httpError = lastError as HttpException;
                if (httpError!=null)
                {
                    //错误代码
                    int httpCode = httpError.GetHttpCode();
                    string strMessage = httpError.Message;
                    Response.StatusCode = httpCode;
                    Response.WriteFile("~/error/errorpage.html");//错误页

                    //Server.Transfer("~/error/errorpage.html");动态页
                    Server.ClearError();
                }
            }
        }
    }
}
