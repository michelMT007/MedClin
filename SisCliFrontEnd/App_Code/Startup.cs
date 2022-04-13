using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SisCliFrontEnd.Startup))]
namespace SisCliFrontEnd
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
