using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 组合模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics compostiteCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            compostiteCG.Add(new Circle("圆"));
            compostiteCG.Add(new Circle("线段B"));
            complexGraphics.Add(compostiteCG);
            Line l = new Line("线段C");
            complexGraphics.Add(l);

            Console.WriteLine("复杂图形的绘制如下");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");

            complexGraphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.ReadKey();
        }
    }
}
