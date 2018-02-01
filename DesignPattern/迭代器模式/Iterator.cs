using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    //迭代器抽象类
    public interface Iterator
    {
        bool MoveNext();
        object GetCurrent();
        void Next();
        void Reset();

    }
}
