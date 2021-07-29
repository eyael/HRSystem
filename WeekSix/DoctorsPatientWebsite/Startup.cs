using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorsPatientWebsite.Startup))]
namespace DoctorsPatientWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
