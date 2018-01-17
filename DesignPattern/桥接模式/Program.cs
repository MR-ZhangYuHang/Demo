using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new ConcreteRemote();

            remoteControl.Implementor = new ChangHong();
            remoteControl.on();
            remoteControl.SetChannel();
            remoteControl.off();

            remoteControl.Implementor = new Samaung();
            remoteControl.on();
            remoteControl.SetChannel();
            remoteControl.off();
            Console.ReadKey();
        }
    }
}
