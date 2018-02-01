using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Tenxun tenxun = new Tenxun("腾讯游戏","有一个更新");

            tenxun.AddObserver(new Subscriber("马化腾"));
            tenxun.AddObserver(new Subscriber("马云"));
            tenxun.Update();
            Console.ReadKey();
        }
    }
}
