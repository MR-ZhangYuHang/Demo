using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLanHu.Startup))]
namespace MVCLanHu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
