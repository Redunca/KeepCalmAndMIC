using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KeepCalmAndMIC.Startup))]
namespace KeepCalmAndMIC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
