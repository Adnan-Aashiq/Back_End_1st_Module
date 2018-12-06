using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZipShip_indiviual.Startup))]
namespace ZipShip_indiviual
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
