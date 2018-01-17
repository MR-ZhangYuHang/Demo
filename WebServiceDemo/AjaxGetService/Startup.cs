using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxGetService.Startup))]
namespace AjaxGetService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
