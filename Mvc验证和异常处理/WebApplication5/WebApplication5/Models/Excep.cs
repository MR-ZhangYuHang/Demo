using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Models
{
    public class Excep : HandleErrorAttribute
    {
        //全局异常处理特性[Excep],错误地址不能进入异常处理
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<string>() { 
                    new KeyValuePair<string,object>("异常信息",filterContext.Exception.Message)
                    }
                };
            }
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
}