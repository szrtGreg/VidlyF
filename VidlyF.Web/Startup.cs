using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyF.Web.Startup))]
namespace VidlyF.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
