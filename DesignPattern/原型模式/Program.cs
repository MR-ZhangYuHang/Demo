using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MingRenPrototype prototype = MingRenPrototype.GetClass();
            prototype.Id = 1;
            prototype.Name = "鸣人";
            prototype.ClassName.ClassName = "7班";
            Console.WriteLine(prototype.Id + prototype.Name + prototype.ClassName.ClassName);
            MingRenPrototype prototype2 = MingRenPrototype.GetClass();
            prototype2.Id = 2;
            prototype2.Name = "佐助";
            prototype2.ClassName.ClassName = "6班";
            Console.WriteLine(prototype2.Id + prototype2.Name + prototype2.ClassName.ClassName);            
            Console.ReadKey();
        }
    }
}
