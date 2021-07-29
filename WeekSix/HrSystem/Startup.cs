using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HrSystem.Startup))]
namespace HrSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
