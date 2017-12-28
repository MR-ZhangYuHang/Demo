using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Web.Hosting;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class FilesController : ApiController
    {
        public CheckFileInfo GetFileInfo(string name, string access_token)
        {

            string _access_token = access_token;

            var file = HostingEnvironment.MapPath("~/App_Data/" + name);//从硬盘中获取name文件

            FileInfo info = new FileInfo(file);
            var hasher = SHA256.Create();
            byte[] hashValue;
            using (Stream s = File.OpenRead(file))
            {
                hashValue = hasher.ComputeHash(s);
            }
            string sha256 = Convert.ToBase64String(hashValue);
            var json = new CheckFileInfo

            {

                BaseFileName = info.Name,//"test.docx",

                OwerId = "admin",

                Size = info.Length,

                SHA256 = "+17lwXXN0TMwtVJVs4Ll+gDHEIO06l+hXK6zWTUiYms=",

                Version = "GIYDCMRNGEYC2MJREAZDCORQGA5DKNZOGIZTQMBQGAVTAMB2GAYA===="

            };

            return json;

        }
        public HttpResponseMessage GetFile(string name, string access_token)
        {

            try
            {

                string _access_token = access_token;

                var file = HostingEnvironment.MapPath("~/App_Data/" + name);//name是文件名

                var rv = new HttpResponseMessage(HttpStatusCode.OK);

                var stream = new FileStream(file, FileMode.Open, FileAccess.Read);

                rv.Content = new StreamContent(stream);

                rv.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                return rv;

            }

            catch (Exception ex)
            {

                var rv = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                var stream = new MemoryStream(UTF8Encoding.Default.GetBytes(ex.Message ?? ""));

                rv.Content = new StreamContent(stream);

                return rv;

            }

        }
    }
}
