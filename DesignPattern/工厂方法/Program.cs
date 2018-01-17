using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator potatoes = new PotatoesFactory();
            Creator tomato = new TomatoFactory();
            Food food1 = tomato.CreateFood();
            food1.Print();

            Food food2 = potatoes.CreateFood();
            food2.Print();
            Console.ReadKey();
        }
        /// <summary>
        /// 食物
        /// </summary>
        public abstract class Food
        {
            //输出菜名
            public abstract void Print();
        }
        /// <summary>
        /// 西红柿炒鸡蛋
        /// </summary>
        public class Tomato : Food
        {
            public override void Print()
            {
                Console.WriteLine("一份西红柿炒鸡蛋");
            }
        }
        /// <summary>
        /// 酸辣土豆丝
        /// </summary>
        public class Potatoes : Food
        {
            public override void Print()
            {
                Console.WriteLine("一份酸辣土豆丝");
            }
        }
        /// <summary>
        /// 抽象工厂类
        /// </summary>
        public abstract class Creator
        {
            public abstract Food CreateFood();
        } 
        public class TomatoFactory:Creator
        {
            public override Food CreateFood()
            {
                return new Tomato();
            }
        }
        public class PotatoesFactory : Creator
        {
            public override Food CreateFood()
            {
                return new Potatoes();
            }
        }
    }
}
