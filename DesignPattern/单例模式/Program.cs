using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singo = Singleton.GetSingleton();
            singo.name="123";
            Console.WriteLine(singo.name);
            Singleton singo1 = Singleton.GetSingleton();
            Console.WriteLine(singo.name);
            Console.ReadKey();
        }
        public class Singleton
        {
            public string name;
            //定义静态变量保存类的实例
            private static Singleton uniqueInstance;
            //定义一个标识确保线程同步
            private static readonly object locker = new object();
            //构造私有函数，使外界不能创建该类的实例
            private Singleton()
            {
                
            }
            /// <summary>
            /// 定义一个公有方法
            /// </summary>
            /// <returns></returns>
            public static Singleton GetSingleton()
            {
                // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                // 双重锁定只需要一句判断就可以了
                if (uniqueInstance==null)
                {
                    lock (locker)
                    {
                        // 如果类的实例不存在则创建，否则直接返回
                        if (uniqueInstance == null)
                        {
                            uniqueInstance = new Singleton();
                        }
                    } 
                }
                return uniqueInstance;
            }
        }
    }
}
