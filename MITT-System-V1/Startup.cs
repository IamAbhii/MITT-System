using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MITT_System_V1.Startup))]
namespace MITT_System_V1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
