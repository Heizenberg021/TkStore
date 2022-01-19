using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TkStore.UI.Startup))]
namespace TkStore.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
