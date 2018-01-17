using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory fc = new BeiJingFactory();
            MiXian mx= fc.CreateMiXian();
            LengMian lm = fc.CreateLengMian();
            lm.print();
            mx.print();
            Console.ReadKey();
        }
        /// <summary>
        /// 抽象工厂
        /// </summary>
        public abstract class Factory
        {
            public abstract MiXian CreateMiXian();
            public abstract LengMian CreateLengMian();
        }

        public class BeiJingFactory:Factory
        {
            public override MiXian CreateMiXian()
            {
                return new BeiJingMiXian();
            }
            public override LengMian CreateLengMian()
            {
                return new BeiJingLengMian();
            }
        }
        public class ShanDongFactory : Factory
        {
            public override MiXian CreateMiXian()
            {
                return new ShanDongMiXian();
            }
            public override LengMian CreateLengMian()
            {
                return new ShanDongLengMian();
            }
        }
        /// <summary>
        /// 米线
        /// </summary>
        public abstract class MiXian
        {
            public abstract void print();
        }
        /// <summary>
        /// 冷面
        /// </summary>
        public abstract class LengMian
        {
            public abstract void print();
        }
        /// <summary>
        /// 北京的米线
        /// </summary>
        public class BeiJingMiXian:MiXian
        {
            public override void print()
            {
                Console.WriteLine("北京的米线");
            }
        }
        /// <summary>
        /// 山东的米线
        /// </summary>
        public class ShanDongMiXian : MiXian
        {
            public override void print()
            {
                Console.WriteLine("山东的米线");
            }
        }
        /// <summary>
        /// 北京的冷面
        /// </summary>
        public class BeiJingLengMian:LengMian
        {
            public override void print()
            {
                Console.WriteLine("北京的冷面");
            }
        }
        /// <summary>
        /// 山东的冷面
        /// </summary>
        public class ShanDongLengMian : LengMian
        {
            public override void print()
            {
                Console.WriteLine("山东的冷面");
            }
        }
    }
}
