using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MicroBdc.Web.Startup))]
namespace MicroBdc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
