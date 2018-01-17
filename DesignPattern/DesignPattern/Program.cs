using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 简单工厂设计模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Food tomato = FoodSimpleFactory.CreateFood("西红柿");
            tomato.Print();
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
        /// 简单工厂类
        /// </summary>
        public class FoodSimpleFactory
        {
            public static Food CreateFood(string type)
            {
                Food food = null;
                if (type.Equals("土豆"))
                {
                    food = new Potatoes();
                }
                else if (type.Equals("西红柿"))
                {
                    food = new Tomato();
                }
                return food;
            }
        }
    }
}
