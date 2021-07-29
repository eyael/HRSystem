using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatagoryExercise.Startup))]
namespace CatagoryExercise
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
