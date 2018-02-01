using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Spinach spinach = new Spinach();
            spinach.CookVegetabel();
            ChineseCabbage chineseCabbage = new ChineseCabbage();
            chineseCabbage.CookVegetabel();
            Console.ReadKey();
        }
    }
}
