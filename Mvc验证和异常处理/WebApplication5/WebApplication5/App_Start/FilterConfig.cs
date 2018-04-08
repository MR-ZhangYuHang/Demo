using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Excep());//添加全局异常处理
            //filters.Add(new CustomAuthorizeAttribute());//添加全局登录验证
        }
    }
}
