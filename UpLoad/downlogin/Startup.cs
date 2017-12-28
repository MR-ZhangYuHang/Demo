using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(downlogin.Startup))]
namespace downlogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
