using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    // 腾讯游戏订阅号类
    public class Tenxun
    {
        public List<IObserver> observers = new List<IObserver>();
        public string Symbol { get; set; }
        public string Info { get; set; }
        public Tenxun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }
        #region 新增对订阅号列表的维护操作
         public void AddObserver(IObserver ob)
         {
             observers.Add(ob);
         }
         public void RemoveObserver(IObserver ob)
         {
             observers.Remove(ob);
         }
         #endregion
        public void Update()
        {
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    // 调用订阅者对象来通知订阅者
                    ob.ReceiveAndPrint(this);
                } 
            }
        }
    }
}
