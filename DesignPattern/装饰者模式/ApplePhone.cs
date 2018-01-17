using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 苹果手机，即装饰着模式中的具体组件类
/// </summary>
namespace 装饰者模式
{
    public class ApplePhone:Phone
    {
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象——苹果手机");
        }
    }
}
