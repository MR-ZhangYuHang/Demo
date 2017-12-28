using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninesky.IDAL;
using System.Linq.Expressions;

namespace Ninesky.DAL
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class 
    {
        protected NineskyDbContext nContext = ContextFactory.GetCurrentContext();
        public T Add(T entity)
        {
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            nContext.SaveChanges();
            return entity;
        }
        public int Count(Expression<Func<T, bool>> prediced)
        {
            return nContext.Set<T>().Count(prediced);
        }
        public bool Update(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return nContext.SaveChanges() > 0;
        }
        public bool Delete(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return nContext.SaveChanges() > 0;
        }
        public bool Exist(Expression<Func<T,bool>> anyLambda)
        {
            return nContext.Set<T>().Any(anyLambda);
        }
        public T Find(Expression<Func<T,bool>> whereLambda)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }
        public IQueryable<T> FindList<S>(Expression<Func<T,bool>> whereLambda,bool isAsc,Expression<Func<T,S>> orderLambda)
        {
            var _list = nContext.Set<T>().Where<T>(whereLambda);
            if (isAsc)
            {
                _list = _list.OrderBy<T, S>(orderLambda);
            }
            else
            {
                _list = _list.OrderByDescending<T, S>(orderLambda);
            }
            return _list;
        }
        public IQueryable<T> FindPageList<S>(int pageIndex,int pageSize,out int totalRecord, Expression<Func<T,bool>> whereLambda,bool isAsc,Expression<Func<T,S>> orderLambda)
        {
            var _list = nContext.Set<T>().Where<T>(whereLambda);
            totalRecord = _list.Count();
            if (isAsc)
            {
                _list = _list.OrderBy<T, S>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                _list = _list.OrderByDescending<T, S>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return _list;
        }
    }
}
