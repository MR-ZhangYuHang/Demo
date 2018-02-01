using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
    public class ConcreteCommand:Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        {

        }

        public override void Action()
        {
            _receiver.Run1000Meters();
        }
    }
}
