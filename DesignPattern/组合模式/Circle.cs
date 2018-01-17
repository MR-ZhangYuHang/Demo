using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 组合模式
{
    public class Circle:Graphics
    {
        public Circle(string name)
            : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("画"+Name);
        }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向简单图形Circle添加其他图形");
        }
        public override void Remove(Graphics g)
        {
            throw new Exception("不能向简单图形Circle移除其他图形");
        }
    }
}
