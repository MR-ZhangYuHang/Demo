using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 长虹牌电视机，重写基类的抽象方法
/// 提供具体的实现
/// </summary>
namespace 桥接模式
{
   public class ChangHong:TV
    {
       public override void on()
       {
           Console.WriteLine("长虹牌电视机已经打开了");
       }
       public override void off()
       {
           Console.WriteLine("长虹牌电视机已经关掉了");
       }
       public override void tuneChannel()
       {
           Console.WriteLine("长虹牌电视机换频道");
       }

    }
}
