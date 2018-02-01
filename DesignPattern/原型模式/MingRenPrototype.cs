using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    public class MingRenPrototype
    {
        private static MingRenPrototype Prop = null;
        public int Id { get; set; }
        public string Name { get; set; }
        public Class ClassName {get;set;}
        private MingRenPrototype()
        {
        }
        public static MingRenPrototype GetClass()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (Prop == null)
            {
                Prop = new MingRenPrototype();
                Prop.ClassName = new Class();
            }
            else
            {
                Prop = (MingRenPrototype)Prop.MemberwiseClone();//浅克隆
                Prop.ClassName = new Class
                {
                    ClassName=Prop.ClassName.ClassName
                };
            }
            return Prop;
        }
    }
}
