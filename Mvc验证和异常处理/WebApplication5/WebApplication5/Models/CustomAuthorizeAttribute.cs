using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Models
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    var r = base.AuthorizeCore(httpContext);
        //    if (r)
        //    {
        //        return httpContext.Session != null && httpContext.Session["uid"] != null;
        //    }
        //    return false;
        //}

        //方法钱添加特性[CustomAuthorize]验证此方法，FilterConfig中添加全局，则所有方法都验证
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session == null || filterContext.HttpContext.Session["user"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/User/Login");
            }
        }

    }
}