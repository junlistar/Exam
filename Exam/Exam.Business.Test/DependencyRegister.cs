using Autofac;
using Autofac.Core;
using Exam.Core.Data;
using Exam.Core.Infrastructure.DependencyManagement;
using Exam.Data;
using Exam.Data.Repositories;
using Exam.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Test
{
    class DependencyRegister : IDependencyRegistrar
    {
        public void Register(Autofac.ContainerBuilder builder, Core.Infrastructure.TypeFinders.ITypeFinder typeFinder)
        {
            #region 数据库

            const string MAIN_DB = "Exam";

            builder.Register(c => new ExamDbContext(MAIN_DB))
                    .As<IDbContext>()
                    .Named<IDbContext>(MAIN_DB)
                    .SingleInstance();

            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(MAIN_DB))
                .SingleInstance();

            #endregion

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IUserInfoBusiness))).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(UserInfoService).Assembly)
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
        }
        public int Order
        {
            get { return 1; }
        }
    }
}
