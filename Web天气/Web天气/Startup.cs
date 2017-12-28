using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web天气.Startup))]
namespace Web天气
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
