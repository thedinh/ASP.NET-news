using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsumingWebServiceASP.NET.Startup))]
namespace ConsumingWebServiceASP.NET
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
