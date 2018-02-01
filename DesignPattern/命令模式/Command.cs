using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
    public abstract class Command
    {
        protected Receiver _receiver;
        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        public abstract void Action();
    }
}
