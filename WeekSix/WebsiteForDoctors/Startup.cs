using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteForDoctors.Startup))]
namespace WebsiteForDoctors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
