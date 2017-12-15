namespace Exam.Data
{
    using EntityFramework.BulkInsert.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class ExamDbContext : DbContext, IDbContext
    {
        public ExamDbContext()
            : base("name=Exam")
        {
            
        }

        public ExamDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        #region 方法区

        public virtual int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction, int? timeout, params object[] parameters)
		{
			throw new System.NotImplementedException();                   
		}

		public virtual IList<TEntity> ExecuteStoredProcedureList<TEntity>(string cmdText, params  object[] parameters)
		{
			throw new System.NotImplementedException();
		}

		public virtual IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
		{
            return base.Database.SqlQuery<TElement>(sql, parameters);
		}

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();            
        }

        public IQueryable<T> Include<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
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
        /// Saves the changes bulk.
        /// </summary>
        /// <returns></returns>
        public void InsertBulk<T>(IEnumerable<T> entities)
        {
            this.BulkInsert(entities);
            SaveChanges();
        }

        #endregion

        #region 帮助方法区

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            //System.Type configType = typeof(LanguageMap);   //any of your configuration classes here
            //var typesToRegister = Assembly.GetAssembly(configType).GetTypes()

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);

                modelBuilder.Configurations.Add(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

            base.OnModelCreating(modelBuilder);
        }    

        #endregion
    }
}

