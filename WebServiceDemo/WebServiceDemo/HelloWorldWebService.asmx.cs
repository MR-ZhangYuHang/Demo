using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace WebServiceDemo
{
    /// <summary>
    /// HelloWorldWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class HelloWorldWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string name)
        {
            Dictionary<string, string> dr = new Dictionary<string, string>();
            dr.Add("a", "b");
            return JsonConvert.SerializeObject(dr); ;
        }
        [WebMethod]
        public int returnint(int i){
        return i;
    }
    }
}
