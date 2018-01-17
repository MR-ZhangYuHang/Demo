using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
   public class Samaung:TV
    {
       public override void on()
       {
           Console.WriteLine("三星牌电视机已经打开了");
       }
       public override void off()
       {
           Console.WriteLine("三星牌电视机已经关掉了");
       }
       public override void tuneChannel()
       {
           Console.WriteLine("三星牌电视机换频道");
       }
    }
}
