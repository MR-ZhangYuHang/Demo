using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 电视机，提供抽象方法
/// </summary>
namespace 桥接模式
{
   public abstract class TV
    {
    public abstract void on();
    public abstract void off();
    public abstract void tuneChannel();
    }
}
