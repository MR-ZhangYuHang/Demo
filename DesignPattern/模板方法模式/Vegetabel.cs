using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板方法模式
{
    public abstract class Vegetabel
    {
        public void CookVegetabel()
        {
            Console.WriteLine("炒蔬菜的一般做法");
            this.pourOil();
            this.HeatOil();
            this.pourVegetable();
            this.stir_fry();
        }
        public void pourOil()
        {
            Console.WriteLine("倒油");
        }
        public void HeatOil()
        {
            Console.WriteLine("把油烧热");
        }
        public abstract void pourVegetable();
        public void stir_fry()
        {
            Console.WriteLine("翻炒");
        }
    }
}
