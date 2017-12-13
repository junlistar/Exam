using System;
using System.Linq;
using System.Linq.Expressions;

namespace Exam.Core.Data
{
    /// <summary>
    /// Lambda排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Orderable<T>
    {
        private bool isInit = false;

        private enum OrderDirection
        {
            Asc,
            Desc
        }

        private IQueryable<T> _queryable;

        public Orderable(IQueryable<T> enumerable)
        {
            _queryable = enumerable;
        }

        public IQueryable<T> Queryable
        {
            get { return _queryable; }
        }

        public Orderable<T> Asc<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            if(isInit)
            {
                _queryable = (_queryable as IOrderedQueryable<T>).ThenBy(keySelector);
            }
            else
            {
                _queryable = _queryable.OrderBy(keySelector);
                isInit = true;
            }

            return this;
        }        

        public Orderable<T> Desc<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            if (isInit)
            {
                _queryable = (_queryable as IOrderedQueryable<T>).ThenByDescending(keySelector);
            }
            else
            {
                _queryable = _queryable.OrderByDescending(keySelector);
                isInit = true;
            }

            return this;
        }
    }
}