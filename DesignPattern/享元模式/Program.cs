using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseWord e1 = FlyweightFactory.GetWord(FlyweightFactory.WordType.E);
            BaseWord l = FlyweightFactory.GetWord(FlyweightFactory.WordType.L);
            BaseWord e2 = FlyweightFactory.GetWord(FlyweightFactory.WordType.E);
            BaseWord v = FlyweightFactory.GetWord(FlyweightFactory.WordType.V);
            BaseWord e3 = FlyweightFactory.GetWord(FlyweightFactory.WordType.E);
            BaseWord n = FlyweightFactory.GetWord(FlyweightFactory.WordType.N);
            Console.WriteLine("{0}{1}{2}{3}{4}{5}",e1.Get(),l.Get(),e2.Get(),v.Get(),e3.Get(),n.Get());
            Console.ReadKey();
        }
    }
}
