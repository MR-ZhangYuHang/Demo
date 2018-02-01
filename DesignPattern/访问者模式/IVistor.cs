using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 访问者模式
{
    public interface IVistor
    {
        void Visit(ElementA a);
        void Visit(ElementB b);
    }
}
