using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
    //教官
    public class Invoke
    {
        public Command _command;
        public Invoke(Command command)
        {
            this._command=command;
        }
        public void ExecuteCommand()
        {
            _command.Action();
        }
    }
}
