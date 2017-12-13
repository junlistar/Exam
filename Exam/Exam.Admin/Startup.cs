using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam.Admin.Startup))]
namespace Exam.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
