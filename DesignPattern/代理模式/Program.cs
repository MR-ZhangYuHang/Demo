using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个代理对象并发出请求
            Person person = new Friend();
            person.BuyProduct();
            Console.ReadKey();
        }
    }
}
