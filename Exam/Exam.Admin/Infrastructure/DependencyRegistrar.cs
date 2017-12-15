using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Exam.Business;
using Exam.Core.Data;
using Exam.Core.Infrastructure.DependencyManagement;
using Exam.Core.Infrastructure.TypeFinders;
using Exam.Data;
using Exam.Data.Repositories;
using Exam.IService;
using Exam.Service;
using System.Linq;
using System.Reflection;

namespace Exam.Admin.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get
            {
                return 0;
            }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
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

            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IUserInfoBusiness))).AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();


            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IUserInfoService))).AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            // 注入Business及接口
            builder.RegisterAssemblyTypes(typeof(UserInfoBusiness).Assembly)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
             

            builder.RegisterAssemblyTypes(typeof(UserInfoService).Assembly)
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
        }
    }
}