using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArsCodex.UI.Startup))]
namespace ArsCodex.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
