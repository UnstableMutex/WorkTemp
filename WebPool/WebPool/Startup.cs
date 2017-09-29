using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPool.Startup))]
namespace WebPool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
