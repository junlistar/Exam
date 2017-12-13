
namespace Exam.Core.Data
{
    using Exam.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    /// <summary>
    /// IRepository<T>
    /// </summary>
    public interface IRepository<T> where T : class, IAggregateRoot
	{
		/// <summary>
		/// 表对象
		/// </summary>
		IQueryable<T> Table { get;}

        /// <summary>
        /// 查找列表，关联属性
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IQueryable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);       

        /// <summary>
        /// 通过Id获取指定对象
        /// </summary>
        T GetById(object id);

		/// <summary>
		/// 插入一个对象
		/// </summary>
		T Insert(T entity);

		/// <summary>
		/// 插入多个对象
		/// </summary>
		void Insert(IEnumerable<T> entities);

		/// <summary>
		/// 更新一个对象
		/// </summary>
		void Update(T entity);

		/// <summary>
		/// 删除一个对象
		/// </summary>
		void Delete(T entity);

		/// <summary>
		/// 删除多个对象
		/// </summary>
		void Delete(IEnumerable<T> entities);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> SqlQuery(string sql, object[] parameters);
	}
}

