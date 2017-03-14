using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(efcv2.Startup))]
namespace efcv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
