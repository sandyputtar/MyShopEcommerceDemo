using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShopEcommerceDemo.UI.Startup))]
namespace MyShopEcommerceDemo.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
