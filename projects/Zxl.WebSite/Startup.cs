using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zxl.WebSite.Startup))]
namespace Zxl.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
