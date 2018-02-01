using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    public class ConcreteList:IListCollection
    {
        int [] collection;
        public ConcreteList(){
            collection=new int[]{2,4,6,8};
        }

        public Iterator GetIterator(){
            return new ConcreteIterator(this);
        }

        public int Length{
            get{return collection.Length;}
        }

        public int GetElement(int index){
            return collection[index];
        }
    }
}
