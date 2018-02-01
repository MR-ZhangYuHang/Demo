using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式
{
    //牌友A
    public class ParterA:AbstractCardPartner
    {
        public override void ChangCount(int Count, AbstractMediator mediator)
        {
            mediator.AWin(Count);
        }
    }
}
