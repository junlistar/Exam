 

namespace Exam.Data.Repositories
{
    using Exam.Core.Data; 
    using Exam.Data;
    using Exam.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Linq.Expressions;

    public class EfRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private IDbSet<T> _entities;

        private IDbContext _dbContext;

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<T>();
                return _entities;

               // return new ExamDbContext("Exam").Set<T>();
            }
        }

        /// <summary>
        /// 表对象
        /// </summary>
        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public EfRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 通过Id获取指定对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 插入一个对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Add(entity);
            this._dbContext.SaveChanges();

            return entity;
        }

        /// <summary>
        /// 插入一个对象
        /// </summary>
        /// <param name="entities"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
                Entities.Add(entity);

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 更新一个对象
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._dbContext.SaveChanges();
        }

        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Remove(entity);

            this._dbContext.SaveChanges();
        }

        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <param name="entities"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
                this.Entities.Remove(entity);

            this._dbContext.SaveChanges();
        }

        /// <summary>
        /// 查找列表，关联属性
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var query = this.Table;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery(string sql, object[] parameters)
        {
            return this._dbContext.SqlQuery<T>(sql, parameters);
        }
    }
}

