using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式
{
    class E:BaseWord
    {
        public E()
        {
            Console.WriteLine("{0}被构造",this.GetType().Name);
        }

        public override string Get()
        {
            return this.GetType().Name;
        }
    }
}
