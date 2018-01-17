using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者模式
{
   public class Decorator:Phone
    {
       private Phone phone;
       public Decorator(Phone p)
       {
           this.phone = p;
       }
       public override void Print()
       {
           if (phone!=null)
           {
               phone.Print();
           }
       }
    }
}
