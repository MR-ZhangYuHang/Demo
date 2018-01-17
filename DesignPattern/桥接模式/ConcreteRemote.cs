using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
   public class ConcreteRemote:RemoteControl
    {
       public override void SetChannel()
       {
           Console.WriteLine("---------------------");
           base.SetChannel();
           Console.WriteLine("---------------------");
       }
    }
}
