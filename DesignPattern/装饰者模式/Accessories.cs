using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者模式
{
   public class Accessories:Decorator
    {
       public Accessories(Phone p)
           : base(p)
       {

       }

       public override void Print()
       {
           base.Print();
           AddAccessories();
       }

       public void AddAccessories()
       {
           Console.WriteLine("现在苹果有漂亮的挂件了");
       }
    }
}
