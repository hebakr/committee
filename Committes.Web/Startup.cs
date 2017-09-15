using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Committes.Web.Startup))]
namespace Committes.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
