using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Valence.Web.Startup))]
namespace Valence.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
