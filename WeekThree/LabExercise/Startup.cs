using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabExercise.Startup))]
namespace LabExercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
