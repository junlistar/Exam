using System.Reflection;
using System.Linq;
using Autofac;
using System.Web.Compilation;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Mvc;
using System;
using System.Web.Http;

namespace Exam.Core.AutoFacIoc
{
    /// <summary>
    /// 依赖注入帮助类
    /// </summary>
    public class AutofacIoc
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        public static void AutofacMvcRegister(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            builder.RegisterControllers(assemblies).PropertiesAutowired();
            builder.RegisterApiControllers(assemblies).PropertiesAutowired();
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterAssemblyTypes(assemblies)
                   .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)
                   .Where(c => c.Name.EndsWith("Service"))
                   .AsSelf()
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void AutofacMvcRegister(object configuration)
        {
            throw new NotImplementedException();
        }
    }
}
