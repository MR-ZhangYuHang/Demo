using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MingRenPrototype prototype = MingRenPrototype.GetClass();
            prototype.Id = 1;
            prototype.Name = "鸣人";
            Console.WriteLine(prototype.Id+prototype.Name);
            MingRenPrototype prototype2 = MingRenPrototype.GetClass();
            prototype2.Id = 2;
            prototype2.Name = "佐助";
            Console.WriteLine(prototype2.Id + prototype2.Name);            
            Console.ReadKey();
        }
        public class MingRenPrototype
        {
            public static MingRenPrototype Prop = null;
            public int Id { get; set; }
            public string Name { get; set; }
            private MingRenPrototype()
            {
            }
            public static MingRenPrototype GetClass()
            {
                // 如果类的实例不存在则创建，否则直接返回
                if (Prop == null)
                {
                    Prop = new MingRenPrototype();
                }
                else
                {
                    Prop = (MingRenPrototype)Prop.MemberwiseClone();
                }
                return Prop;
            }
        }

        //public class ConcretePrototype : MingRenPrototype
        //{
        //    public ConcretePrototype(string id) : base(id) { }

        //    public override MingRenPrototype Clone()
        //    {
        //        return (MingRenPrototype)this.MemberwiseClone();
        //    }
        //}
    }
}
