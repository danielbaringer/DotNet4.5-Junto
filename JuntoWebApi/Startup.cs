using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JuntoWebApi.Startup))]

namespace JuntoWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
