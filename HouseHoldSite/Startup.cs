using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseHoldSite.Startup))]
namespace HouseHoldSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
