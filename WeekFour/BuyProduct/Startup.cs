using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuyProduct.Startup))]
namespace BuyProduct
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
