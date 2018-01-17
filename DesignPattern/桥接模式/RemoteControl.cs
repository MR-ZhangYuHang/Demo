using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 抽象概念中的遥控器，扮演抽象化角色
/// </summary>
namespace 桥接模式
{
   public class RemoteControl
    {
        private TV implementor;

        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }
        /// <summary>
        /// 开电视机，这里抽象类中不再提供实现了，而是调用实现类中的实现
        /// </summary>
        public virtual void on()
        {
            implementor.on();
        }
        /// <summary>
        /// 关电视机
        /// </summary>
        public virtual void off()
        {
            implementor.off();
        }
        /// <summary>
        /// 换频道
        /// </summary>
        public virtual void SetChannel()
        {
            implementor.tuneChannel();
        }

    }
}
