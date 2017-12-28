using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/products")]
    [EnableCors(origins: "http://localhost:1896", headers: "*", methods: "*")]
    public class IPAddressController : ApiController
    {
        private const string CallbackQueryParameter = "callback";
        private static IList<Address> addresses = new List<Address>  
        {   
            new Address(){ IPAddress="1.91.38.31", Province="北京市", City="北京市" },     
            new Address(){ IPAddress = "210.75.225.254", Province = "上海市", City = "上海市"  },  
        };

        [HttpGet, Route("product/add")]
        public string GetIPAddresses()
        {
            Address addresses = new Address() { IPAddress = "1.91.38.31", Province = "北京市", City = "北京市" };
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Address));
            MemoryStream msObj = new MemoryStream();
            //将序列化之后的Json格式数据写入流中
            js.WriteObject(msObj, addresses);
            msObj.Position = 0;
            //从0这个位置开始读取流中的数据
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string json = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            return "callback("+json+")";
            //return Json(addresses);
        }
        [HttpPost, Route("product/update")]
        public string GetIPAddressByIP(string[] address)
        {
            //Address addresses = new Address() { IPAddress = "1.91.38.31", Province = "北京市", City = "北京市" };
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Address));
            MemoryStream msObj = new MemoryStream();
            //将序列化之后的Json格式数据写入流中
            js.WriteObject(msObj, address);
            msObj.Position = 0;
            //从0这个位置开始读取流中的数据
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string json = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            return json ;
        }
        public string Options()
        {

            return null; // HTTP 200 response with empty body

        }
    }
}
