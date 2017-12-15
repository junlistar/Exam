
namespace Exam.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IDbContext 
	{
        IDbSet<T> Set<T>() where T : class;

		int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction, int? timeout, params object[] parameters);

		IList<TEntity> ExecuteStoredProcedureList<TEntity>(string cmdText, params  object[] parameters);

		int SaveChanges();

        void InsertBulk<T>(IEnumerable<T> entities);

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        IQueryable<T> Include<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes);        
    }
}

