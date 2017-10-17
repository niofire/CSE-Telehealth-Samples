using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CSETHSamples_TrustedApp.Startup))]

namespace CSETHSamples_TrustedApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
