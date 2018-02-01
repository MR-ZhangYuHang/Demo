using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    public interface IListCollection
    {
        Iterator GetIterator();
    }
}
