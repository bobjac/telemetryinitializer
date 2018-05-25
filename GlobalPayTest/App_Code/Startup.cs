using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlobalPayTest.Startup))]
namespace GlobalPayTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
