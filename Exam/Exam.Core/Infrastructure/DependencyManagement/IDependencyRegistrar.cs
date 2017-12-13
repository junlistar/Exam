using Autofac;
using Exam.Core.Infrastructure.TypeFinders;

namespace Exam.Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
