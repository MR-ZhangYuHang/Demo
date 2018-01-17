using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetService
{
    class Program
    {
        static void Main(string[] args)
        {
            SFM.MyFirstWebServiceSoapClient web = new SFM.MyFirstWebServiceSoapClient();
            Console.WriteLine(web.HelloWorld("a","b"));
            HelloWorldWebService.HelloWorldWebServiceSoapClient he = new HelloWorldWebService.HelloWorldWebServiceSoapClient();
            Console.WriteLine(he.HelloWorld("zyh"));
            Console.WriteLine(he.returnint(1));
            Console.ReadKey();
        }
    }
}
