using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SqlDependencyTest.Startup))]
namespace SqlDependencyTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
