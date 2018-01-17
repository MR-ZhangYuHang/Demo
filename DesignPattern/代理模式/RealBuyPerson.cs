using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    public class RealBuyPerson:Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("帮我买个IPhone");
        }
    }
}
