using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式
{
    /// <summary>
    /// 字母的抽象类
    /// </summary>
    public abstract class BaseWord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public abstract string Get();
    }
}
