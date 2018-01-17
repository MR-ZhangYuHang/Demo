using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者模式
{
   public class SamSung:Phone
    {
       public override void Print()
       {
           Console.WriteLine("开始执行具体的对象——三星手机");
       }
    }
}
