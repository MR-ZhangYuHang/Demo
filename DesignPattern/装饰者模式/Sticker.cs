using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者模式
{
   public class Sticker:Decorator
    {
       public Sticker(Phone p)
           :base(p)
       {

       }

       public override void Print()
       {
           base.Print();
           AddSticker();
       }
       private void AddSticker()
       {
           Console.WriteLine("现在苹果手机有贴膜了");
       }
    }
}
