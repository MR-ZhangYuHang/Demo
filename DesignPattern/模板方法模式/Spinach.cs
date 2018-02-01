using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板方法模式
{
    public class Spinach:Vegetabel
    {
        public override void pourVegetable()
        {
            Console.WriteLine("倒入菠菜");
        }
    }
}
