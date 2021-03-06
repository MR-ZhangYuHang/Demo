﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Ninesky.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        public static NineskyDbContext GetCurrentContext()
        {
            NineskyDbContext _nContext = CallContext.GetData("NineskyContext") as NineskyDbContext;
            if (_nContext==null)
            {
                _nContext = new NineskyDbContext();
                CallContext.SetData("NineskyContext", _nContext);
            }
            return _nContext;
        }
    }
}
